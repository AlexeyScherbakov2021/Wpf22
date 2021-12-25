using System;
using System.Collections.Generic;
using System.Text;
using Wpf22.Models;
using Wpf22.Services.Base;

namespace Wpf22.Services.Students
{
    class GroupsRepository : RepositoryInMemory<Group>
    {
        public GroupsRepository() : base(TestData.Groups) { }

        protected override void Update(Group Source, Group Destination)
        {
            Destination.Name = Source.Name;
            Destination.Description = Source.Description;
        }
    }
}
