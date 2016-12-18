$(document).ready(function(){


    $('button.scroll_car').click(function()
    {
        var id_car = this.id;
        ChangeCar(id_car);
    })
    $('button.buy_button').click(function()
    {
        alert('Поздравляем! Вы успешно арендовали автомобиль!')
    })

    function ChangeArrowIndex(id, cars)
    {
            var lastid = Number(id) - 1;
            var nextid = Number(id) + 1;
            if (nextid >= cars.cars.length)
                nextid = 0;
            if (lastid < 0)
                lastid = cars.cars.length - 1;
            $("button.scroll_car[name='prev']").attr({
                "id": lastid
            });
            $("button.scroll_car[name='next']").attr({
                "id": nextid
            });
    }

	function ChangeCar(id)
    {
        $.get('/buycar/cars/json', GetCarsSuccess);
		function GetCarsSuccess(cars)
        {
            ChangeArrowIndex(id, cars);
            $('p.car_name').text(cars.cars[id].Name);
            $('p.car_producer').text(cars.cars[id].Producer);
            $('p.car_creation_year').text(cars.cars[id].CreationYear);
            $('p.car_price').text(cars.cars[id].Price);
            $('img.car_image').attr({
                "src": cars.cars[id].Image
            });
        }        
	}	
});