1. Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов

Решение: select c.ClientName, count(cc.Id) as ContactCount from Clients c left join ClientContacts cc on c.Id = cc.ClientId GROUP by c.ClientName

2. Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов

Решение: select c.ClientName, count(cc.Id) as ContactCount from Clients c left join ClientContacts cc on c.Id = cc.ClientId GROUP by c.Id having COUNT(cc.Id)> 2