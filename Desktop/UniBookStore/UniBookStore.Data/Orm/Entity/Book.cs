using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBookStore.Data.Orm.Entity
{
    public class Book: BaseEntity
    {
        [Required(ErrorMessage = "Kitap adı alanı bos geçilemez"), DisplayName(" Kitap Adı: ")]
        public string BookName { get; set; } // zorunu alan

        public string BookShortName { get; set; }  // optional alan nice to have alan kaldirabiliriz gereksiz bulursak buradan.

        [Required(ErrorMessage = "Yayıncı firma alanı bos geçilemez"), DisplayName(" Yayıncı Firma: ")]
        public string Publisher { get; set; }  // zorunu alan

        public string Translator { get; set; }     // nice to have alan kaldirabiliriz gereksiz bulursak buradan.

        [Required(ErrorMessage = "Basım yılı alanı bos geçilemez"), DisplayName(" Basım Yılı: ")]
        public string EditionYear { get; set; }    // basim yili  zorunu alan

        [Required(ErrorMessage = "Kitap adedi alanı bos geçilemez"), DisplayName(" Kitap Adedi: ")]
        public int Quantity { get; set; }          // zorunu alan adet girisi ilk fazda kullanilmayacak. eger online satisa baslarsak adedi kullanacagiz. 

        [Required(ErrorMessage = "Kitap fiyat alanı bos geçilemez"), DisplayName(" Kitap Fiyat: ")]
        public decimal Price  { get; set; }        // zorunu alan kitap satis fiyati

        public string Explanation { get; set; }    // optional alan kitap aciklamasi. nice to have alan kaldirabiliriz gereksiz bulursak buradan.

        public string BookCondition { get; set; }  // optional alan kitabin durumu nasil yipranmis, temiz etc. bunu enumaration olarak dropbox'dan sectirebiliriz eklersek ama suan icin nice to have

        public int? LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public virtual Language Language { get; set; }  // kitap hangi dilde yazilmis id si. language tablosunda isimler var

        public int? BookUniversityID { get; set; }
        [ForeignKey("BookUniversityID")]
        public virtual University University { get; set; }

        public int? UniDepartmentID { get; set; }
        [ForeignKey("UniDepartmentID")]
        public virtual UniDepartment UniDepartment { get; set; }

        public int? WriterID { get; set; }
        [ForeignKey("WriterID")]
        public virtual Writer Writer { get; set; }

        public int? FrontUserID { get; set; }
        [ForeignKey("FrontUserID")]
        public virtual FrontUser FrontUser { get; set; }

        public virtual List<BookPublisherInterim> Publishers { get; set; }

        public virtual List<ImagePath> ImagePath { get; set; }

    }
}
