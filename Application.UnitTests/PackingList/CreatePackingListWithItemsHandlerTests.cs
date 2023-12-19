namespace Application.UnitTests.PackingList
{
	using PackIT.Application.Services;
	using PackIT.Application.Exceptions;
	using PackIT.Application.DTO.External;
	using PackIT.Application.PackingList.Commands.CreatePackingList;

	using PackIT.Domain.Enums;
	using PackIT.Domain.Factory;
	using PackIT.Domain.Entities;
	using PackIT.Domain.ValueObjects;
	using PackIT.Domain.Repositories;

	using MediatR;
	using NSubstitute;
	using Xunit;
	using Xunit.Abstractions;
	using FluentAssertions;

	public class CreatePackingListWithItemsHandlerTests
	{
		private readonly IRequestHandler<CreatePackingListWithItems> commandHandler;
		private readonly IPackingListRepository repository;
		private readonly IWeatherService weatherService;
		private readonly IPackingListReadService readService;
		private readonly IPackingListFactory packingListFactory;
		private readonly ITestOutputHelper testOutput;

		private Task Act(CreatePackingListWithItems command, CancellationToken cancellation)
			=> this.commandHandler.Handle(command, cancellation);

		[Fact]
		public async Task Handle_Throws_PackingListAlreadyExistsException_WhenListWithSameNameExists()
		{
			var command = new CreatePackingListWithItems(
				Guid.NewGuid(),
				"MyList",
				1,
				Gender.Male,
				default);
			this.readService.ExistsByNameAsync(command.Name).Returns(true);

			var exception = await Record.ExceptionAsync(() => this.Act(command, new CancellationToken()));

			exception.Should().NotBeNull();
			exception.Should().BeOfType<PackingListAlreadyExistsException>();
		}

		[Fact]
		public async Task Handle_Throws_MissingLocalizationWeatherException_WhenWeatherIsNotReturnFromService()
		{
			var command = new CreatePackingListWithItems(
				Guid.NewGuid(),
				"MyList",
				1,
				Gender.Male,
				new LocalizationWriteModel("Sofia", "Bulgaria"));
			this.readService.ExistsByNameAsync(command.Name).Returns(false);
			this.weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDto));

			var exception = await Record.ExceptionAsync(() => this.Act(command, new CancellationToken()));

			exception.Should().NotBeNull();
			exception.Should().BeOfType<MissingLocalizationWeatherException>();
		}

		[Fact]
		public async Task Handle_Adds_CreatedPackingListToRepository()
		{
			var command = new CreatePackingListWithItems(
				Guid.NewGuid(),
				"MyList",
				1,
				Gender.Male,
				new LocalizationWriteModel("Sofia", "Bulgaria"));
			this.readService.ExistsByNameAsync(command.Name).Returns(false);
			this.weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDto(32.2));
			this.packingListFactory.CreatePackingListWithDefaultItems(
				command.Id,
				command.Name,
				Arg.Any<Localization>(),
				command.Days,
				Arg.Any<Temperature>(),
				command.Gender).Returns(default(PackingList));

			var exception = await Record.ExceptionAsync(() => this.Act(command, new CancellationToken()));
			exception.Should().BeNull();
			await this.repository.Received(1).AddAsync(Arg.Any<PackingList>());
			var packingList = this.repository.GetAsync(new PackingListId(Guid.NewGuid()));
			packingList.Should().NotBeNull();
		}

		public CreatePackingListWithItemsHandlerTests(ITestOutputHelper testOutput)
		{
			this.repository = Substitute.For<IPackingListRepository>();
			this.weatherService = Substitute.For<IWeatherService>();
			this.readService = Substitute.For<IPackingListReadService>();
			this.packingListFactory = Substitute.For<IPackingListFactory>();
			this.commandHandler = new CreatePackingListWithItemsHandler(
				this.repository,
				this.packingListFactory,
				this.readService,
				this.weatherService);
			this.testOutput = testOutput;
		}
    }
}
