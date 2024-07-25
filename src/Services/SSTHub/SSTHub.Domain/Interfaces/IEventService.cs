using SSTHub.Domain.ViewModels.Event;

namespace SSTHub.Domain.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventListItemViewModel>> GetByHubIdAsync(int hubId);
        Task<IEnumerable<EventListItemViewModel>> GetByOrganizationIdAsync(int organizationId);
        Task<EventDetailsViewModel> GetByIdAsync(int id);
        Task<int> CreateAsync(EventCreateViewModel createViewModel);
        Task UpdateAsync(int id, EventEditItemViewModel editItemViewModel);
    }
}
