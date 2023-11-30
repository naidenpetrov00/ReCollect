namespace PackIT.Application.PackingList.Commands.CreatePackingList
{
	using PackIT.Domain.Enums;
	using PackIT.Domain.Factory;
	using PackIT.Domain.Repositories;

	using PackIT.Application.Services;
	using PackIT.Application.Exceptions;

	using System.Threading;
	using System.Threading.Tasks;
	using MediatR;

	public record CreatePackingListWithItems(
		Guid Id,
		string Name,
		ushort Days,
		Gender Gender,
		LocalizationWriteModel Localization) : IRequest;

	public record LocalizationWriteModel(string City, string Country);

	public class CreatePackingListWithItemsHandler : IRequestHandler<CreatePackingListWithItems>
	{
		private readonly IPackingListRespository respository;
		private readonly IPackingListFactory packingListFactory;
		private readonly IPackingListReadService packingListReadService;

		public CreatePackingListWithItemsHandler(
			IPackingListRespository respository,
			IPackingListFactory packingListFactory,
			IPackingListReadService packingListReadService)
		{
			this.respository = respository;
			this.packingListFactory = packingListFactory;
			this.packingListReadService = packingListReadService;
		}

		public async Task Handle(CreatePackingListWithItems request, CancellationToken cancellationToken)
		{
			if (await this.packingListReadService.ExistsByNameAsync(request.Name))
			{
				throw new PackingListAlreadyExistsException(request.Name);
			}
		}
	}
}

