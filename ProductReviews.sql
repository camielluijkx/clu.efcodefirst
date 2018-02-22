use [ProductReviews]

--delete from dbo.[Reviews]
--delete from dbo.[Products]

select
	  p.[ProductId]
	, p.[Category]
	, p.[Name]
	, p.[Price]
	, r.[ReviewId]
	, r.[Title]
	, r.[Description]
from dbo.[Products] p
	left outer join dbo.[Reviews] r
		on r.[ProductId] = p.[ProductId]