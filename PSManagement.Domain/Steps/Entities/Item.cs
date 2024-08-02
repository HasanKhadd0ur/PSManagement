using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Domain.Steps.Entities
{
    public class Item : BaseEntity
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Money Price { get; set; }
        public Item()
        {

        }
    }

}
