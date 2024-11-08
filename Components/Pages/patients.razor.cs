using PatientSystem.Entities.Patients;
using PatientSystem.Services.Dtos.Patients;
using Blazorise;
using Blazorise.DataGrid;
using PatientSystem.Services.Patients;
using Volo.Abp.Application.Dtos;

namespace PatientSystem.Components.Pages
{
    public partial class Patients
    {
        private string SearchText { get; set; } = string.Empty;
        private int CurrentPage { get; set; } = 0;
        private int PageSize { get; set; } = 10;
        private int TotalCount { get; set; }
        private List<PatientDto> Entities { get; set; } = new List<PatientDto>();
        private int? FilterAge { get; set; }
        private DateTime? FilterAdmissionDate { get; set; }
        private PatientStatus? FilterStatus { get; set; }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<PatientDto> e)
        {
            CurrentPage = e.Page;
            PageSize = e.PageSize;

            var query = await PatientAppService.GetListAsync(
                new PagedAndSortedResultRequestDto
                {
                    MaxResultCount = PageSize,
                    SkipCount = CurrentPage * PageSize,
                    Sorting = e.Columns.Where(c => c.SortDirection != SortDirection.Default)
                        .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                        .JoinAsString(",")
                }
            );

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query.Items = query.Items
                    .Where(p => p.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                p.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (FilterAge.HasValue)
            {
                query.Items = query.Items
                    .Where(p => p.Age > FilterAge.Value)
                    .OrderBy(p => p.Age)
                    .ToList();
            }

            if (FilterAdmissionDate.HasValue)
            {
                query.Items = query.Items
                    .Where(p => p.AdmissionDate >= FilterAdmissionDate.Value)
                    .OrderBy(p => p.AdmissionDate)
                    .ToList();
            }

            if (FilterStatus.HasValue)
            {
                query.Items = query.Items
                    .Where(p => p.Status == FilterStatus.Value)
                    .ToList();
            }

            Entities = query.Items.ToList();
            TotalCount = (int)query.TotalCount;
            await InvokeAsync(StateHasChanged);
        }

        private async void OnSearch()
        {
            CurrentPage = 0;
            await OnDataGridReadAsync(new DataGridReadDataEventArgs<PatientDto>(
                DataGridReadDataMode.Paging,
                new List<DataGridColumn<PatientDto>>(),
                new List<DataGridColumn<PatientDto>>(),
                CurrentPage,
                PageSize,
                0,
                0,
                default
            ));
            await InvokeAsync(StateHasChanged);
        }

        private async void OnFilter()
        {
            CurrentPage = 0;
            await OnDataGridReadAsync(new DataGridReadDataEventArgs<PatientDto>(
                DataGridReadDataMode.Paging,
                new List<DataGridColumn<PatientDto>>(),
                new List<DataGridColumn<PatientDto>>(),
                CurrentPage,
                PageSize,
                0,
                0,
                default
            ));
            await InvokeAsync(StateHasChanged);
        }

        private async void OnReset()
        {
            SearchText = string.Empty;
            FilterAge = null;
            FilterAdmissionDate = null;
            FilterStatus = null;
            CurrentPage = 0;
            await OnDataGridReadAsync(new DataGridReadDataEventArgs<PatientDto>(
                DataGridReadDataMode.Paging,
                new List<DataGridColumn<PatientDto>>(),
                new List<DataGridColumn<PatientDto>>(),
                CurrentPage,
                PageSize,
                0,
                0,
                default
            ));
            await InvokeAsync(StateHasChanged);
        }

        private async Task DeleteEntityAsync(PatientDto patient)
        {
            var confirmMessage = GetDeleteConfirmationMessage(patient);
            if (await Message.Confirm(confirmMessage))
            {
                await PatientAppService.DeleteAsync(patient.Id);
                await OnDataGridReadAsync(new DataGridReadDataEventArgs<PatientDto>(
                    DataGridReadDataMode.Paging,
                    new List<DataGridColumn<PatientDto>>(),
                    new List<DataGridColumn<PatientDto>>(),
                    CurrentPage,
                    PageSize,
                    0,
                    0,
                    default
                ));
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}