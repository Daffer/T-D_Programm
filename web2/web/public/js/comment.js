$(document).ready(function(){

	$('button.change_comment').click(function()
    {
		var id_comment = this.id;
		ChangeComment(id_comment);	 
	})

    $('button.scroll_comment').click(function()
    {
        var id_comment = this.id;
        ChangeComment(id_comment);
    })

    function ChangeIndexArrow(id, comments)
    {
            var lastid = Number(id) - 1;
            var nextid = Number(id) + 1;
            if (nextid >= comments.comments.length)
                nextid = 0;
            if (lastid < 0)
                lastid = comments.comments.length - 1;
            $("button.scroll_comment[name='left']").attr({
                "id": lastid
            });
            $("button.scroll_comment[name='rigth']").attr({
                "id": nextid
            });
    }

	function ChangeComment(id)
    {
        $.get('/comments/json', GetCommentsSuccess);
		function GetCommentsSuccess(comments)
        {
            ChangeIndexArrow(id, comments);
            $('h1.comment_title').text(comments.comments[id].title);
            $('p.comment_text').text(comments.comments[id].text);
            $('img.comment_image').attr({
                "src": comments.comments[id].image
            });
        }        
	}	
});