using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Api.Business
{
    public static class BaseMessages
    {
        //Success
        public const string SuccessInsert = "Registro cadastrado com sucesso";
        public const string SuccessGet = "Consulta realizada com sucesso";
        public const string SuccessUpdate = "Registro atualizado com sucesso";
        public const string SuccessDelete = "Registro removido com sucesso";
        public const string UserFound = "Usuario encontrado com sucesso";

        //Erros
        public const string ErrorGet = "Houve um erro ao consultar os registros";
        public const string ErrorInsert = "Houve um erro ao inserir o registro";
        public const string ErrorUpdate = "Houve um erro ao atualizar o registro";
        public const string ErrorDelete = "Houve um erro ao remover o registro";
        public const string UserNotFound = "Usuario ou senha inválidas";

        //Não encontrados
        public const string NotFoundGet = "Nenhum registro foi encontrado";

        public const string SendEmailSucess = "Email enviado com sucesso!";
    }
}
