using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Entities
{
    public class ToDo
    {
        public int ID { get; set; }

       
        [MinLength(2, ErrorMessage = "Başlık bilgisi en az iki karakter içermeli!")]
        [MaxLength(20, ErrorMessage = "Başlık bilgisi en fazla yirmi karakter içermeli!")]
        public string Baslik { get; set; }

        [MinLength(2, ErrorMessage = "Açıklama bilgisi en az iki karakter içermeli!")]
        [MaxLength(200, ErrorMessage = "Açıklama bilgisi en fazla iki yüz karakter içermeli!")]
        public string Aciklama { get; set; }

        public bool AktifMi { get; set; }

        public DateTime? OlusturmaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime? DegistimeTarihi { get; set; }
        public bool Bildirildi { get; set; }
    }
}
