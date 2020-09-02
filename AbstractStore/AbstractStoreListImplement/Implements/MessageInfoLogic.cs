using AbstractJewerlyStoreBusinessLogic.BindingModels;
using AbstractJewerlyStoreBusinessLogic.Interfaces;
using AbstractJewerlyStoreBusinessLogic.ViewModels;
using AbstractStoreListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractStoreListImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly DataListSingleton source;

        public MessageInfoLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            foreach (var message in source.Messages)
            {
                if (message.MessageId == model.MessageId)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
            }
            source.Messages.Add(CreateModel(model, new MessageInfo()));
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var message in source.Messages)
            {
                if (model != null)
                {
                    if (message.MessageId == model.MessageId)
                    {
                        result.Add(CreateViewModel(message));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(message));
            }
            return result;
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.MessageId = model.MessageId;
            message.ClientId = model.ClientId;
            message.Subject = model.Subject;
            message.Body = model.Body;
            message.DateDelivery = model.DeliveryDate;
            return message;
        }

        private MessageInfoViewModel CreateViewModel(MessageInfo message)
        {
            return new MessageInfoViewModel
            {
                MessageId = message.MessageId,
                SenderName = message.SenderName,
                Subject = message.Subject,
                Body = message.Body,
                DateDelivery = message.DateDelivery
            };
        }
    }
}
