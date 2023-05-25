using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator: AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must not more than 70 characters.");

        RuleFor(x => x.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{ProperyName} cannot be less than one..");

        RuleFor(q => q)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type already exists");


        _leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
