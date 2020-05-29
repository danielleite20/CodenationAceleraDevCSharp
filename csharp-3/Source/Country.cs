using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            var estadosBr = new List<State>
            {
                new State("Acre", "AC", 164123.040),
                new State("Alagoas", "AL", 27778.506),
                new State("Amapa", "AP", 142828.521),
                new State("Amazonas", "AM", 1559159.148),
                new State("Bahia", "BA", 564733.177),
                new State("Ceara", "CE", 148920.472),
                new State("Distrito Federal", "DF", 5779.999),
                new State("Espirito Santo", "ES", 46095.583),
                new State("Goias", "GO", 340111.783),
                new State("Maranhao", "MA", 331937.450),
                new State("Mato Grosso", "MT", 903366.192),
                new State("Mato Grosso do Sul", "MS", 357145.532),
                new State("Minas Gerais", "MG", 586522.122),
                new State("Para", "PA", 1247954.666),
                new State("Paraiba", "PB", 56585.000),
                new State("Parana", "PR", 199307.922),
                new State("Pernambuco", "PE", 98311.616),
                new State("Piaui", "PI", 251577.738),
                new State("Rio de Janeiro", "RJ", 43780.172),
                new State("Rio Grande do Norte", "RN", 52811.047),
                new State("Rio Grande do Sul", "RS", 281730.223),
                new State("Rondonia", "RO", 237590.547),
                new State("Roraima", "RR", 224300.506),
                new State("Santa Catarina", "SC", 95736.165),
                new State("Sao Paulo", "SP", 248222.362),
                new State("Sergipe", "SE", 21915.116),
                new State("Tocantins", "TO", 277720.520)
            };

            return estadosBr.OrderByDescending(i => i.Extension).Take(10).ToArray();

            }
        }
    }

    /************************************************************************************
         *  Feita sobrecarga do construtor. Para receber valores da Area
         *
         *1. Preciso entender onde esses dados fixos ficariam melhor: 
         *    - Na classe Country
         *    - Na classe State 
         *    - Em uma nova classe de acesso a uma fonte de dados (CountryData, StateData...)
         *
         *    E qual padrao que se segue para isso... ?
         *    
         * 2. Nesse desafio foi necessario retornar apenas estados brasileiros, porem a classe
         *    eh geral Country, o ideal seria criar uma Classe "filha" para o Brasil ou quem 
         *    deve cuidar disso eh quem vai usar (instanciar) a classe Country? 
         *    
         **/