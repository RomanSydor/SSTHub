using SSTHub.Domain.ViewModels.Event;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface IEventService
    {
        Task<ImmutableList<EventListItemViewModel>> GetByHubIdAsync(int hubId);
        Task<ImmutableList<EventListItemViewModel>> GetByOrganizationIdAsync(int organizationId);
        Task<EventDetailsViewModel> GetByIdAsync(int id);
        Task<int> CreateAsync(EventCreateViewModel createViewModel);
        Task UpdateAsync(int id, EventEditItemViewModel editItemViewModel);
    }
}
