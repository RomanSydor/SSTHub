﻿using SSTHub.Domain.Interfaces;

namespace SSTHub.Application.Infrastructure
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDateTimeNow() => DateTime.Now;
    }
}
