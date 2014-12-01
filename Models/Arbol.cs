using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Models
{
    public class Arbol
    {
        public  List<int> ids;
        //static int RolId { get; set; }
        static dynamic Dinamico { get; set; }

        public static dynamic getActualMenu()
        {
            MenuContext db = new MenuContext();
            return buildArbol(db.Items.ToList());
        }

        public  dynamic getMenuByRol(int rol_id)
        {
            //RolId = rol_id;
            MenuContext db = new MenuContext();
            var pantallas = db.Permissions.Where(x => x.rol_id == rol_id && x.visible == true).ToList();
            foreach (var p in pantallas)
            {
               getIdPadre(db.Items.Where(x => x.ItemId == p.ItemID).SingleOrDefault());
            }
            var item = db.Items.Where(x => ids.Contains(x.ItemId)).Distinct().ToList();
            return buildArbol(db.Items.Where(x => ids.Contains(x.ItemId)).Distinct().ToList());
        }

        private bool getIdPadre(Item p)
        {
            MenuContext db = new MenuContext();
            if (p.parent == 0)
            {
                List<int> obj = new List<int>();
                obj.Add(p.ItemId);
                contatenaLists(obj);
                return true;
            }
            else
            {
                var padre = db.Items.Where(x => x.ItemId == p.parent).SingleOrDefault();
                List<int> obj = new List<int>();
                obj.Add(padre.ItemId);
                obj.Add(p.ItemId);
                contatenaLists(obj);
                return padre.parent == 0 ? true : getIdPadre(padre);
            }
        }

        private void contatenaLists(List<int> obj)
        {
            List<int> list = new List<int>();
            if (ids != null)
            {
                foreach (var l in ids)
                {
                    obj.Add(l);
                }
            }
            ids = obj;

        }
        public static dynamic buildArbol(List<Item> items)
        {
            var list = new List<dynamic>();
            var parents = items.Where(i => i.parent == 0).ToList().OrderBy(x => x.orden);
            foreach (var p in parents)
            {
                Dinamico = getMenu(p, items);
                list.Add(Dinamico);
            }
            return list;
        }



        private static dynamic getMenu(Item p, List<Item> items)
        {
            dynamic padre;
            ItemMenu item = new ItemMenu();
            item.icono = p.icono;
            item.ItemId = p.ItemId;
            item.name = p.name;
            item.parent = p.parent;
            item.title = p.title;
            item.url = p.url;
            item.orden = p.orden;
            item.hijos = getHijos(p, items);
            padre = item;
            return padre;
        }

        private static System.Collections.Generic.List<ItemMenu> getHijos(Item p, List<Item> items)
        {
            MenuContext db = new MenuContext();
            List<ItemMenu> new_items = new List<ItemMenu>();
            var hijos = items.Where(i => i.parent == p.ItemId).ToList().OrderBy(x => x.orden);
            foreach (var padre in hijos)
            {
                ItemMenu item = new ItemMenu();
                item.icono = padre.icono;
                item.ItemId = padre.ItemId;
                item.name = padre.name;
                item.parent = padre.parent;
                item.title = padre.title;
                item.url = padre.url;
                item.orden = padre.orden;
                item.hijos = getHijos(padre, items);
                new_items.Add(item);
            }
            return new_items;
        }

    }

    class ItemMenu
    {
        public int ItemId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int parent { get; set; }
        public string title { get; set; }
        public string icono { get; set; }
        public int orden { get; set; }
        public List<ItemMenu> hijos { get; set; }
    }
}
