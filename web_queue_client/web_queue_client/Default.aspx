<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_queue_client.WebForm1" %>

<!DOCTYPE html>
<meta http-equiv="REFRESH" content="10">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />

	<!-- Optional theme -->
	<link rel="stylesheet" href="css/bootstrap-theme.min.css" />

	<!-- Latest compiled and minified JavaScript -->
	<script src="js/bootstrap.min.js"></script>
	<script language="javascript">
		function submit() {
			window.SUBMIT();
		}
	</script>
</head>
<body style="background-image: url(img/random_grey_variations.png);">
	<form id="form1" runat="server">
		<div style="margin-left:auto; margin-right:auto; width: 45%; padding-top: 10%">
			<div style="background-color: white; padding: 25px; border-radius: 10px">
				<div class="row" style="padding-top: 0px;">
					<div style="padding-left: 0px">
						<label class="text-muted">Cервер:</label>
						<label class="text-danger" style="font-size: large">localhost</label>
					</div>
				</div>
				<div class="row" style="padding-bottom: 15px">
					<div  style="padding-left: 0px">
						<label class="text-muted">Состояние сервера:</label>
						<strong>
							<label runat="server" id="locked" class="text-danger" style="font-size: medium"></label>
						</strong>
						<label runat="server" id="free" class="text-success" style="font-size: medium"></label>
					</div>
				</div>

				<div class="form-group">
					<div class="row" style="padding-left: 0px; padding-bottom: 15px">
						<div style="padding-left: 0px">
							<select class="form-control" id="users" runat="server" onchange="submit()" onserverchange="UserChange">
								<option>Федотов Сергей</option>
								<option>Малышев Григорий</option>
								<option>Гончаров Андрей</option>
								<option>Диев Андрей</option>
								<option>Радченко Анна</option>
								<option>Викулина Дарья</option>
								<option>Ешмеков Кирилл</option>
								<option>Федосеев Ян</option>
							</select>
						</div>
					</div>

					<div class="row" style="padding-left: 0px;">
						<input type="button" id="push" runat="server" value="Встать в очередь" class="btn btn-success" onserverclick="Push" />
						<input type="button" id="pop" runat="server" value="Выйти из очереди" class="btn btn-danger" onserverclick="Pop" />
					</div>

				</div>

				<div class="row">
					<div style="padding-left: 0px;">
						<label class="text-muted">Очередь:</label>
						<div style="background-color: white">
							<table class="table table-hover table-bordered table-striped" id="queue" runat="server">
							</table>
						</div>
					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
