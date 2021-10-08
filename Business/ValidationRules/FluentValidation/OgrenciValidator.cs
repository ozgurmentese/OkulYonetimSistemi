using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class OgrenciValidator : AbstractValidator<Ogrenci>
    {
        public OgrenciValidator()
        {
            RuleFor(o => o.BolumId).NotEmpty();

            RuleFor(o => o.Ad).NotEmpty().WithMessage("Boş geçilemez!");
            RuleFor(o => o.Ad).Length(3, 20).WithMessage("Ad minimum 3 maksimum 30 karakterde olmalı");
            RuleFor(o => TurkishCharacterReplace(o.Ad)).Must(IsLetter).WithMessage("Ad alanı sadece harf içermek zorundadır");

            RuleFor(o => o.Soyad).NotEmpty();
            RuleFor(o => o.Soyad).MinimumLength(3).WithMessage(" Soyad minimum 3 karakterde olmalı");
            RuleFor(o => TurkishCharacterReplace(o.Soyad)).Must(IsLetter).WithMessage("Soyadi alanı sadece harf içermek zorundadır");

            RuleFor(o => o.Cinsiyet).NotEmpty();

            RuleFor(o => o.DogumTarihi).NotEmpty();
            RuleFor(o => o.DogumTarihi).Must(DogumTarihiKontrol).WithMessage("Geçersiz Tarih");

            RuleFor(o => o.OgretmenId).NotEmpty();
        }

        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return regex.IsMatch(arg);
        }

        private bool DogumTarihiKontrol(DateTime tarih)
        {
            if (tarih.Year < 2000 || tarih >= DateTime.Now)
                return false;
            return true;
        }

        private string TurkishCharacterReplace(string metin)
        {
            metin = metin.Replace("ı", "i");
            metin = metin.Replace("ö", "o");
            metin = metin.Replace("ü", "u");
            metin = metin.Replace("ğ", "g");
            metin = metin.Replace("ç", "c");
            metin = metin.Replace("ş", "s");
            metin = metin.Replace("Ü", "U");
            metin = metin.Replace("İ", "I");
            metin = metin.Replace("Ö", "O");
            metin = metin.Replace("Ğ", "G");
            metin = metin.Replace("Ç", "C");
            metin = metin.Replace("Ş", "S");
            metin = metin.Replace(" ", "");
            return metin;
        }
    }
}
