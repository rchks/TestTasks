1. Написать запрос, который возвращает интервалы для одинаковых Id

Решение: select d.id as Id, d.dt as Sd, dd.dt as Ed from Dates d inner join dates dd on dd.Id = d.Id where dd.Dt > d.Dt GROUP by d.Dt