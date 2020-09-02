using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractJewerlyStoreFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractJewerlyStoreFileImplement.Implements
{
    public class MessageInfoLogic
    {
        private readonly FileDataListSingleton source;

        public MessageInfoLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            MessageInfo element = source.Messages.FirstOrDefault(rec =>
            rec.MessageId == model.MessageId);
            if (element != null)
            {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }
            int? clientId = source.Clients.FirstOrDefault(rec =>
            rec.Login == model.FromMailAddress)?.Id;
            source.Messages.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = clientId,
                SenderName = model.FromMailAddress,
                DeliveryDate = model.DeliveryDate,
                Subject = model.Subject,
                Body = model.Body
            });
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            return source.Messages
            .Where(rec => model == null || rec.ClientId == model.ClientId)
            .Select(rec => new MessageInfoViewModel
            {
                MessageId = rec.MessageId,
                SenderName = rec.SenderName,
                DateDelivery = rec.DeliveryDate,
                Subject = rec.Subject,
                Body = rec.Body
            })
            .ToList();
        }
    }
}
