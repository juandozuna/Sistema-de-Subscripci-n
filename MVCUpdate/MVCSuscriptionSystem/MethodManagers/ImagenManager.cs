using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Drawing;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class ImagenManager
    {
        
        public static int SubirImagen(HttpPostedFileBase image1)
        {
            MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
            Models.Image img = new Models.Image();
            img.ImageData = new byte[image1.ContentLength];
            image1.InputStream.Read(img.ImageData, 0, image1.ContentLength);
            db.Images.Add(img);
            db.SaveChanges();
            return IdImagenSubida(img);

        }

        public static int IdImagenSubida(Models.Image image)
        {

            MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
            try
            {
                if (image != null)
                    return db.Images.Find(image.imagesID).imagesID;
            }
            catch (NullReferenceException e)
            {
                return 1;
            }
            return 0;
        }

        public static string RetornarSourceImagen(int? idImagen)
        {
            MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
            Models.Image img = db.Images.Find(idImagen);
            if (img != null)
            {
                var base64 = Convert.ToBase64String(img.ImageData);
                var imgsrc = String.Format("data:image/jpeg;base64,{0}", base64);
                img.Nombre = imgsrc;
                db.Entry(img).State = EntityState.Modified;
                db.SaveChanges();
                return imgsrc;
            }
            else
            {
                return "http://www.tea-tron.com/antorodriguez/blog/wp-content/uploads/2016/04/image-not-found-4a963b95bf081c3ea02923dceaeb3f8085e1a654fc54840aac61a57a60903fef-584x276.png";
            }

        }


    }
}