﻿using HR.LeaveManagement.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Email;

public interface IEmailSender
{
    ValueTask<bool> SendEmail(EmailMessage email);
}


