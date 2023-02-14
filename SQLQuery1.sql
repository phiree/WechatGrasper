----delete from SDTASpecialLocalProductDetail 
select p.* from SDTASpecialLocalProductDetail d 
inner join SDTASpecialLocalProductDetailPictures p 
on d.id=p.SpecialLocalProducId 
where d.id ='fb017e934c28152f014c2bfab1b5127d'
