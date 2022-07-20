using System;
using System.Collections.Generic;

namespace DEVinBricks.Models
{
    public partial class ValorFreteEstado : Log
    {
        int estadoID { get; set; }
        Estado estado { get; set; }
        decimal valor { get; set; }

    }
}
