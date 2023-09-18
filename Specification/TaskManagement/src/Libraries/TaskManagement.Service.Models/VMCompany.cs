using AutoMapper;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Shared;

namespace TaskManagement.Service.Models
{
    public class VMCompany : IVM
    {
        /// <summary>
        /// Name of the company.
        /// </summary>
        [MaxLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Address of the company.
        /// </summary>
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Owner of the company.
        /// </summary>
        [MaxLength(50)]
        public string Owner { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}
