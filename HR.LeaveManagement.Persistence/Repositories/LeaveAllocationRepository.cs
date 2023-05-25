using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async ValueTask AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
    }

    public async ValueTask<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId && x.Period == period);
    }

    public async ValueTask<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _context.LeaveAllocations.Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.Id == id);
        return leaveAllocation!;
    }

    public async ValueTask<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        var leaveAllocations = await _context.LeaveAllocations.Include(x => x.LeaveType).ToListAsync();
        return leaveAllocations;
    }

    public async ValueTask<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        var leaveAllocations = await _context.LeaveAllocations.Where(x => x.EmployeeId == userId).Include(x => x.LeaveType).ToListAsync();
        return leaveAllocations;
    }

    public async ValueTask<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        var leaveAllocation = await _context.LeaveAllocations.FirstOrDefaultAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId);
        return leaveAllocation;
    }
}
