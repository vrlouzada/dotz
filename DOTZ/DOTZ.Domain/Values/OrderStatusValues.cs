using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DOTZ.Domain.Values
{
    public enum OrderStatusValues
    {
        [Description("Pedido realizado.")]
        ORDER_REQUESTED = 1,
        [Description("Embalando pedido.")]
        PACKING_ORDER = 2,
        [Description("Enviado a transportadora.")]
        SENT_TO_CARRIES = 3,
        [Description("Saiu para entrega.")]
        LEFT_TO_DELLIVERY = 4,
        [Description("Entregue.")]
        DELLIVERED = 5

    }
}
