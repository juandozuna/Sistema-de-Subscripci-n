using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class ImagenManager
    {
        
        public static void SubirImagen(HttpPostedFileBase image)
        {
            EntityModel db = new EntityModel();
            Models.Image img = new Models.Image();
            img.Nombre = image.FileName;
            img.ImageData = new byte[image.ContentLength];
            db.Images.Add(img);
            db.SaveChanges();

        }

        public static int IdImagenSubida()
        {
            EntityModel db = new EntityModel();
            return db.Images.Last().imagesID;
        }

        public string RetornarSourceImagen(int idImagen)
        {
            EntityModel db = new EntityModel();
            Models.Image img = db.Images.Find(idImagen);
            if (img != null)
            {
                var base64 = Convert.ToBase64String(img.ImageData);
                var imgsrc = String.Format("data:image/gif;base64,{0}", base64);
                return imgsrc;
            }
            else
            {
                return "http://www.tea-tron.com/antorodriguez/blog/wp-content/uploads/2016/04/image-not-found-4a963b95bf081c3ea02923dceaeb3f8085e1a654fc54840aac61a57a60903fef-584x276.png";
            }

        }
    }
}