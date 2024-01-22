﻿using StackOverflowClone.Application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowClone.Application.Services
{
    public interface IAnswerService
    {
        Task AddAnswer(Answer entity);
        Task DeleteTag(Guid id);
        Task<Answer?> GetAnswerById(Guid id);
        Task Update(Answer entity);
    }
}
