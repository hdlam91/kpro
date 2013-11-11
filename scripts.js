var dato = new Date();
dato.
var source = {'realtorId': 0, 'prodId': 0, 'responsibleRealtor': 'test', 'type': 0, 'price': 1337, 'zipcode': 1337, 'zipArea': 'baerum',  'location': 'trondheim', 'headLine': 'line', 'adress':'adress 37'}

$.ajax({type: "POST", dataType: "json", url: "/api/MasterAPI", data: JSON.stringify({model:source})});

var source = {'':{'RealtorId': 0, 'ProductId': 0, 'ResponsibleRealtor': 'test', 'Type': 0, 'Price': 1337, 'ZipCode': 1337, 'ZipArea': 'baerum',  'Location': 'trondheim', 'HeadLine': 'line', 'Adress':'adress 37'}}


var source = {'':{RealtorId: 0, ProductId: 0, ResponsibleRealtor: 'test', Type: 0, Price: 1337, ZipCode: 1337, ZipArea: 'baerum',  Location: 'trondheim', HeadLine: 'line', Adress:'adress 37'}}
$.ajax({type: "POST", dataType: "json", url: "/api/MasterAPI", data: JSON.stringify({model:source})});


RealEstateAdInfo.realtorId=0&RealEstateAdInfo.prodId=0&RealEstateAdInfo.responsibleRealtor=test&RealEstateAdInfo.type=0&RealEstateAdInfo.price=1337&RealEstateAdInfo.zipcode=1337&RealEstateAdInfo.zipArea=baerum&RealEstateAdInfo.location=trondheim&RealEstateAdInfo.headLine=line&RealEstateAdInfo.adress=adress37