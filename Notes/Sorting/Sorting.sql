

/*  Sorting */

use OFFSETFETCH



declare @SortColumn VARCHAR(50)= 'gender',
		@SortOrder  VARCHAR(5) = 'desc'
													       


select	*
from	Patient

order by	(case when lower(@SortColumn) = ''				and lower(@SortOrder) = ''     then PatientId end) asc,
            (case when lower(@SortColumn) = ''				and lower(@SortOrder) = 'desc' then PatientId end) desc,            
			(case when lower(@SortColumn) = 'FirstName'		and lower(@SortOrder) = 'asc'  then FirstName end) asc,
			(case when lower(@SortColumn) = 'FirstName'		and lower(@SortOrder) = 'desc' then FirstName end) desc,
			(case when lower(@SortColumn) = 'LastName'		and lower(@SortOrder) = 'asc'  then LastName end) asc,
			(case when lower(@SortColumn) = 'LastName'		and lower(@SortOrder) = 'desc' then LastName end) desc,
			(case When lower(@SortColumn)= 'gender'			and lower(@SortOrder) = ''	   then gender end ) asc,
			(case When lower(@SortColumn)= 'gender'			and lower(@SortOrder) = 'desc'	   then gender end ) desc
			


/* Paging and Sorting combine */


declare @SortColumn VARCHAR(50)= 'FirstName',
		@SortOrder  VARCHAR(5) = 'asc',
		@PageNumber INT = 2,
		@PageSize INT = 3  											       


select	*
from	Patient

order by	(case when lower(@SortColumn) = ''				and lower(@SortOrder) = ''     then PatientId end) asc,
            (case when lower(@SortColumn) = ''				and lower(@SortOrder) = 'desc' then PatientId end) desc,            
			(case when lower(@SortColumn) = 'FirstName'		and lower(@SortOrder) = 'asc'  then FirstName end) asc,
			(case when lower(@SortColumn) = 'FirstName'		and lower(@SortOrder) = 'desc' then FirstName end) desc,
			(case when lower(@SortColumn) = 'LastName'		and lower(@SortOrder) = 'asc'  then LastName end) asc,
			(case when lower(@SortColumn) = 'LastName'		and lower(@SortOrder) = 'desc' then LastName end) desc	


offset (@PageNumber - 1) * @PageSize rows
fetch next @PageSize rows only







