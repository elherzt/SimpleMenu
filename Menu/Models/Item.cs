using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Menu.Models
{
    public class ItemOptions
    {
        static public Item agregar(Item item)
        {
            MenuContext db = new MenuContext();
            try {
                db.Items.Add(item);
                db.SaveChanges();
            }
            catch {
                item.ItemId = 0;
            }
            return item;
        }

        static public Boolean eliminar(int ItemId)
        {
            MenuContext db = new MenuContext();
            try
            {
                var item = db.Items.Where(x => x.ItemId == ItemId).SingleOrDefault();
                db.Items.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public Boolean actualizar(Item item)
        {
            MenuContext db = new MenuContext();
            try
            {
                var old_item = db.Items.Where(x => x.ItemId == item.ItemId).SingleOrDefault();
                old_item.icono = item.icono;
                old_item.name = item.name;
                old_item.orden = item.orden;
                old_item.parent = item.parent;
                old_item.title = item.title;
                old_item.url = item.url;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}