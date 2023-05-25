using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        ValueTask<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        ValueTask<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
        ValueTask<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
        ValueTask<bool> AllocationExists(string userId, int leaveTypeId, int period);
        ValueTask AddAllocations(List<LeaveAllocation> allocations);
        ValueTask<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
    }
}