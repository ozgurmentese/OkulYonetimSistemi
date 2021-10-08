using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class DigerPersonelValidator:AbstractValidator<DigerPersonel>
    {
        public DigerPersonelValidator()
        {
            RuleFor(d => d.BolumId).NotEmpty();

            RuleFor(d => d.Ad).NotEmpty();
            RuleFor(d => d.Ad).Length(3, 20).WithMessage("Ad minimum 3 maksimum 30 karakterde olmalı");
            RuleFor(o => TurkishCharacterReplace(o.Ad)).Must(IsLetter).WithMessage("Ad alanı sadece harf içermek zorundadır");

            RuleFor(d => d.Soyad).NotEmpty();
            RuleFor(d => d.Soyad).MinimumLength(3).WithMessage(" Soyad minimum 3 karakterde olmalı");
            RuleFor(d => TurkishCharacterReplace(d.Soyad)).Must(IsLetter).WithMessage("Soyadi alanı sadece harf içermek zorundadır");

            RuleFor(d => d.Cinsiyet).NotEmpty();

            RuleFor(d => d.DogumTarihi).NotEmpty();
            RuleFor(d => d.DogumTarihi).Must(DogumTarihiKontrol).WithMessage("Geçersiz Tarih");


        }
        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return regex.IsMatch(arg);
        }

        private bool DogumTarihiKontrol(DateTime tarih)
        {
            if (tarih.Year < 1930 && tarih >= DateTime.Now)
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
