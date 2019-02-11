﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieSelector2.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FilmyEntities : DbContext
    {
        public FilmyEntities()
            : base("name=FilmyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<turnieje> turnieje { get; set; }
        public virtual DbSet<tytuly> tytuly { get; set; }
    
        public virtual int hsp_turniejeInsert(Nullable<int> id_turnieju, Nullable<int> id_filmu, string nick, Nullable<int> lokata, Nullable<System.DateTime> data_wstawienia)
        {
            var id_turniejuParameter = id_turnieju.HasValue ?
                new ObjectParameter("id_turnieju", id_turnieju) :
                new ObjectParameter("id_turnieju", typeof(int));
    
            var id_filmuParameter = id_filmu.HasValue ?
                new ObjectParameter("id_filmu", id_filmu) :
                new ObjectParameter("id_filmu", typeof(int));
    
            var nickParameter = nick != null ?
                new ObjectParameter("nick", nick) :
                new ObjectParameter("nick", typeof(string));
    
            var lokataParameter = lokata.HasValue ?
                new ObjectParameter("lokata", lokata) :
                new ObjectParameter("lokata", typeof(int));
    
            var data_wstawieniaParameter = data_wstawienia.HasValue ?
                new ObjectParameter("data_wstawienia", data_wstawienia) :
                new ObjectParameter("data_wstawienia", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("hsp_turniejeInsert", id_turniejuParameter, id_filmuParameter, nickParameter, lokataParameter, data_wstawieniaParameter);
        }
    
        public virtual int hsp_turniejInsertByTytul(Nullable<int> id_turnieju, string tytul, string nick, Nullable<int> lokata, Nullable<System.DateTime> data_wstawienia)
        {
            var id_turniejuParameter = id_turnieju.HasValue ?
                new ObjectParameter("id_turnieju", id_turnieju) :
                new ObjectParameter("id_turnieju", typeof(int));
    
            var tytulParameter = tytul != null ?
                new ObjectParameter("tytul", tytul) :
                new ObjectParameter("tytul", typeof(string));
    
            var nickParameter = nick != null ?
                new ObjectParameter("nick", nick) :
                new ObjectParameter("nick", typeof(string));
    
            var lokataParameter = lokata.HasValue ?
                new ObjectParameter("lokata", lokata) :
                new ObjectParameter("lokata", typeof(int));
    
            var data_wstawieniaParameter = data_wstawienia.HasValue ?
                new ObjectParameter("data_wstawienia", data_wstawienia) :
                new ObjectParameter("data_wstawienia", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("hsp_turniejInsertByTytul", id_turniejuParameter, tytulParameter, nickParameter, lokataParameter, data_wstawieniaParameter);
        }
    
        public virtual int hsp_tytulyInsert(string tytul, string tytul_org, string rezyseria, Nullable<int> rok, string kategoria, Nullable<int> dlugosc, string link, Nullable<System.DateTime> data_dodania, Nullable<System.DateTime> obejrzany, Nullable<int> ocena, string obsada, string opis, string kraj, byte[] poster, Nullable<decimal> imdb, string zrodlo)
        {
            var tytulParameter = tytul != null ?
                new ObjectParameter("tytul", tytul) :
                new ObjectParameter("tytul", typeof(string));
    
            var tytul_orgParameter = tytul_org != null ?
                new ObjectParameter("tytul_org", tytul_org) :
                new ObjectParameter("tytul_org", typeof(string));
    
            var rezyseriaParameter = rezyseria != null ?
                new ObjectParameter("rezyseria", rezyseria) :
                new ObjectParameter("rezyseria", typeof(string));
    
            var rokParameter = rok.HasValue ?
                new ObjectParameter("rok", rok) :
                new ObjectParameter("rok", typeof(int));
    
            var kategoriaParameter = kategoria != null ?
                new ObjectParameter("kategoria", kategoria) :
                new ObjectParameter("kategoria", typeof(string));
    
            var dlugoscParameter = dlugosc.HasValue ?
                new ObjectParameter("dlugosc", dlugosc) :
                new ObjectParameter("dlugosc", typeof(int));
    
            var linkParameter = link != null ?
                new ObjectParameter("link", link) :
                new ObjectParameter("link", typeof(string));
    
            var data_dodaniaParameter = data_dodania.HasValue ?
                new ObjectParameter("data_dodania", data_dodania) :
                new ObjectParameter("data_dodania", typeof(System.DateTime));
    
            var obejrzanyParameter = obejrzany.HasValue ?
                new ObjectParameter("obejrzany", obejrzany) :
                new ObjectParameter("obejrzany", typeof(System.DateTime));
    
            var ocenaParameter = ocena.HasValue ?
                new ObjectParameter("ocena", ocena) :
                new ObjectParameter("ocena", typeof(int));
    
            var obsadaParameter = obsada != null ?
                new ObjectParameter("obsada", obsada) :
                new ObjectParameter("obsada", typeof(string));
    
            var opisParameter = opis != null ?
                new ObjectParameter("opis", opis) :
                new ObjectParameter("opis", typeof(string));
    
            var krajParameter = kraj != null ?
                new ObjectParameter("kraj", kraj) :
                new ObjectParameter("kraj", typeof(string));
    
            var posterParameter = poster != null ?
                new ObjectParameter("poster", poster) :
                new ObjectParameter("poster", typeof(byte[]));
    
            var imdbParameter = imdb.HasValue ?
                new ObjectParameter("imdb", imdb) :
                new ObjectParameter("imdb", typeof(decimal));
    
            var zrodloParameter = zrodlo != null ?
                new ObjectParameter("zrodlo", zrodlo) :
                new ObjectParameter("zrodlo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("hsp_tytulyInsert", tytulParameter, tytul_orgParameter, rezyseriaParameter, rokParameter, kategoriaParameter, dlugoscParameter, linkParameter, data_dodaniaParameter, obejrzanyParameter, ocenaParameter, obsadaParameter, opisParameter, krajParameter, posterParameter, imdbParameter, zrodloParameter);
        }
    
        public virtual ObjectResult<hsp_tytulySelect_Result> hsp_tytulySelect(Nullable<bool> obejrzane, Nullable<int> ile)
        {
            var obejrzaneParameter = obejrzane.HasValue ?
                new ObjectParameter("obejrzane", obejrzane) :
                new ObjectParameter("obejrzane", typeof(bool));
    
            var ileParameter = ile.HasValue ?
                new ObjectParameter("ile", ile) :
                new ObjectParameter("ile", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hsp_tytulySelect_Result>("hsp_tytulySelect", obejrzaneParameter, ileParameter);
        }
    
        public virtual ObjectResult<hsp_tytulySelectAll_Result> hsp_tytulySelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hsp_tytulySelectAll_Result>("hsp_tytulySelectAll");
        }
    
        public virtual ObjectResult<hsp_tytulySelectById_Result> hsp_tytulySelectById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hsp_tytulySelectById_Result>("hsp_tytulySelectById", idParameter);
        }
    
        public virtual int hsp_tytulyUpdate(Nullable<int> id, string tytul, string tytul_org, string rezyseria, Nullable<int> rok, string kategoria, Nullable<int> dlugosc, string link, Nullable<System.DateTime> data_dodania, Nullable<System.DateTime> obejrzany, Nullable<int> ocena, string obsada, string opis, string kraj, byte[] poster, Nullable<decimal> imdb, string zrodlo)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var tytulParameter = tytul != null ?
                new ObjectParameter("tytul", tytul) :
                new ObjectParameter("tytul", typeof(string));
    
            var tytul_orgParameter = tytul_org != null ?
                new ObjectParameter("tytul_org", tytul_org) :
                new ObjectParameter("tytul_org", typeof(string));
    
            var rezyseriaParameter = rezyseria != null ?
                new ObjectParameter("rezyseria", rezyseria) :
                new ObjectParameter("rezyseria", typeof(string));
    
            var rokParameter = rok.HasValue ?
                new ObjectParameter("rok", rok) :
                new ObjectParameter("rok", typeof(int));
    
            var kategoriaParameter = kategoria != null ?
                new ObjectParameter("kategoria", kategoria) :
                new ObjectParameter("kategoria", typeof(string));
    
            var dlugoscParameter = dlugosc.HasValue ?
                new ObjectParameter("dlugosc", dlugosc) :
                new ObjectParameter("dlugosc", typeof(int));
    
            var linkParameter = link != null ?
                new ObjectParameter("link", link) :
                new ObjectParameter("link", typeof(string));
    
            var data_dodaniaParameter = data_dodania.HasValue ?
                new ObjectParameter("data_dodania", data_dodania) :
                new ObjectParameter("data_dodania", typeof(System.DateTime));
    
            var obejrzanyParameter = obejrzany.HasValue ?
                new ObjectParameter("obejrzany", obejrzany) :
                new ObjectParameter("obejrzany", typeof(System.DateTime));
    
            var ocenaParameter = ocena.HasValue ?
                new ObjectParameter("ocena", ocena) :
                new ObjectParameter("ocena", typeof(int));
    
            var obsadaParameter = obsada != null ?
                new ObjectParameter("obsada", obsada) :
                new ObjectParameter("obsada", typeof(string));
    
            var opisParameter = opis != null ?
                new ObjectParameter("opis", opis) :
                new ObjectParameter("opis", typeof(string));
    
            var krajParameter = kraj != null ?
                new ObjectParameter("kraj", kraj) :
                new ObjectParameter("kraj", typeof(string));
    
            var posterParameter = poster != null ?
                new ObjectParameter("poster", poster) :
                new ObjectParameter("poster", typeof(byte[]));
    
            var imdbParameter = imdb.HasValue ?
                new ObjectParameter("imdb", imdb) :
                new ObjectParameter("imdb", typeof(decimal));
    
            var zrodloParameter = zrodlo != null ?
                new ObjectParameter("zrodlo", zrodlo) :
                new ObjectParameter("zrodlo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("hsp_tytulyUpdate", idParameter, tytulParameter, tytul_orgParameter, rezyseriaParameter, rokParameter, kategoriaParameter, dlugoscParameter, linkParameter, data_dodaniaParameter, obejrzanyParameter, ocenaParameter, obsadaParameter, opisParameter, krajParameter, posterParameter, imdbParameter, zrodloParameter);
        }
    
        public virtual int TytulySelectSimple(string tytul, Nullable<bool> obejrzane)
        {
            var tytulParameter = tytul != null ?
                new ObjectParameter("tytul", tytul) :
                new ObjectParameter("tytul", typeof(string));
    
            var obejrzaneParameter = obejrzane.HasValue ?
                new ObjectParameter("obejrzane", obejrzane) :
                new ObjectParameter("obejrzane", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TytulySelectSimple", tytulParameter, obejrzaneParameter);
        }
    
        public virtual ObjectResult<hsp_tytulySelectSimpleAll_Result> hsp_tytulySelectSimpleAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hsp_tytulySelectSimpleAll_Result>("hsp_tytulySelectSimpleAll");
        }
    
        public virtual ObjectResult<FilmEF> GetFilmyAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FilmEF>("GetFilmyAll");
        }
    
        public virtual ObjectResult<hsp_turniejeSelectByIdFilmu_Result> hsp_turniejeSelectByIdFilmu(Nullable<int> id_filmu)
        {
            var id_filmuParameter = id_filmu.HasValue ?
                new ObjectParameter("id_filmu", id_filmu) :
                new ObjectParameter("id_filmu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<hsp_turniejeSelectByIdFilmu_Result>("hsp_turniejeSelectByIdFilmu", id_filmuParameter);
        }
    
        public virtual ObjectResult<SkresleniaEF> GetSkresleniaByIdFilmu(Nullable<int> id_filmu)
        {
            var id_filmuParameter = id_filmu.HasValue ?
                new ObjectParameter("id_filmu", id_filmu) :
                new ObjectParameter("id_filmu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SkresleniaEF>("GetSkresleniaByIdFilmu", id_filmuParameter);
        }
    }
}