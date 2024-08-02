﻿using PSManagement.Domain.Customers.Aggregate;
using System;

namespace PSManagement.Domain.Projects.Aggregate
{
    public record ProposalInfo (
        int ProposingBookNumber ,
        DateTime ProposingBookDate
        );

}
