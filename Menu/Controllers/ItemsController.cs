using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Menu.Models;


namespace Menu.Controllers
{
    public class ItemsController : Controller
    {
        public Item Add(Item item)
        {
            return ItemOptions.agregar(item);
        }

        public Boolean Remove(int ItemId)
        {
            return ItemOptions.eliminar(ItemId);
        }

        public Boolean Update(Item item)
        {
            return ItemOptions.actualizar(item);
        }
    }
}
