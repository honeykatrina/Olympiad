using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DataLayer.Context
{
    public class ContextInitializer: DropCreateDatabaseAlways<OlympiadContext>
    {
    }
}