using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using MySql.Data.MySqlClient;
using ProjetoTCCMiauDote.Models;

namespace ProjetoTCCMiauDote.Models
{
    public class Banco
    {
        public static MySqlConnection Conexao;
        public static MySqlCommand Comando;
        public static MySqlDataAdapter Adaptador;
        public static DataTable DatTable;


        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");
                Conexao.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("erro========",ex);
            }
        } 

        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand("create database if not exists MiauDoteDatabase;use MiauDoteDatabase;Cor varchar(40) not null,Foto blob,Genero boolean not null,TipoAnimal varchar(40) not null,Porte varchar(40) not null,EstadoAdocao varchar(40) not null,Raca_id int references Raca (idRaca),primary key (idAnimal));create table if not exists Moderador(idModerador int auto_increment,Nome varchar(40) not null,Email varchar(40) not null,Senha varchar(40) not null,primary key (idModerador));create table if not exists ModeradorAbrigo(idModeradorAbrigo int auto_increment,Nome varchar(40) not null,Email varchar(40) not null,Senha varchar(40) not null,Moderador_id int references Moderador (idModerador),primary key (idModeradorAbrigo));create table if not exists Pessoa(idPessoa int auto_increment,Nome varchar(40) not null,\r\n    Email varchar(40) not null,\r\n    Senha varchar(40) not null,\r\n    DataNascimento date,\r\n    CEP int,\r\n    Endereco varchar(40),\r\n    Numero varchar(40),\r\n    Bairro varchar(40),\r\n    Cidade varchar(40),\r\n    Estado varchar(40),\r\n    Complemento varchar(40),\r\n    Telefone int,\r\n    Renda double,\r\n    QNTPessoasCasa int,\r\n    ComprovanteResidencia blob,\r\n    OutroAnimal varchar(40),\r\n    TamanhoCasa varchar(40),\r\n    LocalAdequado varchar(40),\r\n    primary key (idPessoa)\r\n);\r\n\r\ncreate table if not exists NotaAbrigo(\r\n\tidNotaAbrigo int auto_increment,\r\n    Nota double,\r\n    Pessoa_id int references Pessoa (idPessoa),\r\n    primary key (idNotaAbrigo)\r\n);\r\n\r\ncreate table if not exists Abrigo(\r\n\tidAbrigo int auto_increment,\r\n    Nome varchar(40) not null,\r\n    Email varchar(40) not null,\r\n\tCEP int,\r\n    Endereco varchar(40),\r\n    Numero varchar(40),\r\n    Bairro varchar(40),\r\n    Cidade varchar(40),\r\n    Estado varchar(40),\r\n    Complemento varchar(40),\r\n    TipoAbrigo varchar(40),\r\n\tTelefone int,\r\n    ModeradorAbrigo_id int references ModeradorAbrigo (idModeradorAbrigo),\r\n    Moderador_id int references Moderador (idModerador),\r\n    NotaAbrigo_id int references NotaAbrigo (idNotaAbrigo),\r\n    Animal_id int references Animal (idAnimal),\r\n    primary key (idAbrigo)\r\n);\r\n\r\ncreate table if not exists NovaAdocao(\r\n\tidNovaAdocao int auto_increment,\r\n    Abrigo_id int references Abrigo (idAbrigo),\r\n    Pessoa_id int references Pessoa (idPessoa),\r\n    primary key (idNovaAdocao)\r\n);\r\n\r\ncreate table if not exists Adoçao(\r\n\tidAdocao int auto_increment,\r\n    DataAdocao date,\r\n    OBS varchar(40),\r\n    Motivo varchar(40),\r\n    StatusAdocao varchar(40),\r\n    NovaAdocao_id int references NovaAdocao (idNovaAdocao),\r\n    primary key (idAdocao)\r\n);", Conexao);
                Comando.ExecuteNonQuery();
                FecharConexao();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
