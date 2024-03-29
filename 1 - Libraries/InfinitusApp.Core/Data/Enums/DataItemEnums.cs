﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Enums
{
    public static class DataItemEnums
    {
        public enum DataItemType
        {
            NotFound,
            Generic,
            Company,
            Department,
            Product,
            Vehicle,
            Service,
            Event,
            Book,
            ImageGroup,
            Document,
            Speaker,
            Sponsor,
            Property,
            Curriculum,
            Pet,
            Person,
            PropertyTenancy,
            Inscription,
            Eat,
            Additional,
            City,
            Local,
            Hotel,
            Bedroom
        };

        public static string ToPresentation(this DataItemType dataItemType, bool plural = false)
        {
            switch (dataItemType)
            {
                case DataItemType.NotFound:
                    return "Não Encontrado";
                case DataItemType.Product:
                    return plural ? "Produtos" : "Produto";
                case DataItemType.Vehicle:
                    return plural ? "Veiculos" : "Veiculo";
                case DataItemType.Service:
                    return plural ? "Serviços" : "Serviço";
                case DataItemType.Event:
                    return plural ? "Eventos" : "Evento";
                case DataItemType.ImageGroup:
                    return plural ? "Grupo de Imagens" : "Grupo de Imagem";
                case DataItemType.Document:
                    return plural ? "Documentos" : "Documento";
                case DataItemType.Speaker:
                    return plural ? "Palestrantes" : "Palestrante";
                case DataItemType.Sponsor:
                    return plural ? "Patrocinadores" : "Patrocinador";
                case DataItemType.Property:
                    return plural ? "Propriedades" : "Propriedade";
                case DataItemType.Curriculum:
                    return plural ? "Currículos" : "Curriculo";
                case DataItemType.Book:
                    return plural ? "Livros" : "Livro";
                case DataItemType.Company:
                    return plural ? "Negócios" : "Negócio";
                case DataItemType.Pet:
                    return plural ? "Animais de Estimação" : "Animal de Estimação";
                case DataItemType.PropertyTenancy:
                    return plural ? "Propriedades Alugavel" : "Propriedade Alugavel";
                case DataItemType.Department:
                    return plural ? "Departamentos" : "Departamento";
                case DataItemType.Person:
                    return plural ? "Pessoas" : "Pessoa";
                case DataItemType.Eat:
                    return plural ? "Comidas" : "Comida";
                case DataItemType.Inscription:
                    return plural ? "Inscrições" : "Inscrição";
                case DataItemType.Additional:
                    return plural ? "Adicionais" : "Adicional";
                case DataItemType.City:
                    return plural ? "Cidades" : "Cidade";
                case DataItemType.Local:
                    return plural ? "Locais" : "Local";
                case DataItemType.Hotel:
                    return plural ? "Hoteis" : "Hotel";
                case DataItemType.Bedroom:
                    return plural ? "Quartos" : "Quarto";
                default:
                    return "Não Encontrado";
            }
        }

        public static string ToPresentation(this string dataItemType, bool plural = false)
        {
            switch (dataItemType)
            {
                case "NotFound":
                    return "Não Encontrado";
                case "Product":
                    return plural ? "Produtos" : "Produto";
                case "Vehicle":
                    return plural ? "Veiculos" : "Veiculo";
                case "Service":
                    return plural ? "Serviços" : "Serviço";
                case "Event":
                    return plural ? "Eventos" : "Evento";
                case "ImageGroup":
                    return plural ? "Grupo de Imagens" : "Grupo de Imagem";
                case "Document":
                    return plural ? "Documentos" : "Documento";
                case "Speaker":
                    return plural ? "Palestrantes" : "Palestrante";
                case "Sponsor":
                    return plural ? "Patrocinadores" : "Patrocinador";
                case "Property":
                    return plural ? "Propriedades" : "Propriedade";
                case "Curriculum":
                    return plural ? "Currículos" : "Curriculo";
                case "Book":
                    return plural ? "Livros" : "Livro";
                case "Company":
                    return plural ? "Negócios" : "Negócio";
                case "Pet":
                    return plural ? "Animais de Estimação" : "Animal de Estimação";
                case "PropertyTenancy":
                    return plural ? "Propriedades Alugavel" : "Propriedade Alugavel";
                case "Department":
                    return plural ? "Departamentos" : "Departamento";
                case "Person":
                    return plural ? "Pessoas" : "Pessoa";
                case "Eat":
                    return plural ? "Comidas" : "Comida";
                case "Inscription":
                    return plural ? "Inscrições" : "Inscrição";
                case "Additional":
                    return plural ? "Adicionais" : "Adicional";
                case "City":
                    return plural ? "Cidades" : "Cidade";
                case "Local":
                    return plural ? "Locais" : "Local";
                case "Hotel":
                    return plural ? "Hoteis" : "Hotel";
                case "Bedroom":
                    return plural ? "Quartos" : "Quarto";
                default:
                    return "Não Encontrado";
            }
        }

        public static string GetIcon(this DataItemType dataItemType)
        {
            switch (dataItemType)
            {
                case DataItemType.Product:
                    return "\uf02c";
                case DataItemType.Vehicle:
                    return "\uf1b9";
                case DataItemType.Service:
                    return "\uf4c4  ";
                case DataItemType.Event:
                    return "\uf073";
                case DataItemType.ImageGroup:
                    return "\uf03e";
                case DataItemType.Document:
                    return "\uf05b";
                case DataItemType.Speaker:
                    return "\uf130";
                case DataItemType.Sponsor:
                    return "\uf6f1";
                case DataItemType.Property:
                    return "\uf015";
                case DataItemType.Curriculum:
                    return "\uf15c";
                case DataItemType.Book:
                    return "\uf02d";
                case DataItemType.Company:
                    return "\uf54e";
                case DataItemType.Pet:
                    return "\uf1b0";
                case DataItemType.Department:
                    return "\uf07c";
                case DataItemType.Person:
                    return "\uf406";
                case DataItemType.Eat:
                    return "\uf2e7";
                case DataItemType.Inscription:
                    return "\uf573";
                case DataItemType.Additional:
                    return "\uf217";
                case DataItemType.City:
                    return "\uf64f";
                case DataItemType.Local:
                    return "\uf57d";

                case DataItemType.NotFound:
                default:
                    return "\uf00d";
            }
        }

        public static string ToPresentationNew(this DataItemType dataItemType, bool plural = false)
        {
            var text = plural ? "Novos " : "Novo ";

            switch (dataItemType)
            {
                case DataItemType.Eat:
                case DataItemType.ImageGroup:
                case DataItemType.Person:
                case DataItemType.Property:
                case DataItemType.PropertyTenancy:
                    text = plural ? "Novas " : "Nova ";
                    break;
            }

            text += dataItemType.ToPresentation(plural);

            return text;
        }

        public static string ToPresentationMy(this DataItemType dataItemType, bool plural = false)
        {
            var text = plural ? "Meus " : "Meu ";

            switch (dataItemType)
            {
                case DataItemType.Eat:
                case DataItemType.ImageGroup:
                case DataItemType.Person:
                case DataItemType.Property:
                case DataItemType.PropertyTenancy:
                    text = plural ? "Minhas " : "Minha ";
                    break;
            }

            text += dataItemType.ToPresentation(plural);

            return text;
        }
    }
}
