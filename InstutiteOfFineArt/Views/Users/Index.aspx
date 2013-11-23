<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InstutiteOfFineArt.Views.Users.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Users management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
	<h1>Users Management <strong><small>(11)</small></strong>
		<a href="New.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-plus-sign"></span> Create new</a>
	</h1>
	<hr>
	<div class="row">
		<div class="col-md-4 pull-right">
			<input type="text" class="form-control" placeholder="Insert name or email here...">
		</div>
	</div>
	<br>
	<div>
		<table class="table table-hover">
			<thead>
				<tr>
					<th><center>Id</center></th>
					<th>Username</th>
					<th>Date registered</th>
					<th>Role</th>
					<th>Status</th>
					<th><center>Action</center></th>                                      
				</tr>
			</thead>   
			<tbody>
				<tr>
					<td><center>1</center></td>
					<td>Donna R. Folse</td>
					<td>2012/05/06</td>
					<td>Editor</td>
					<td><span class="label label-success">Active</span>
					</td>
					<td>
						<center>
							<div class="btn-group">
								<a href="Edit.aspx" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></a>
							</div>
						</center>
					</td>                            
				</tr>
				<tr>
					<td><center>2</center></td>
					<td>Emily F. Burns</td>
					<td>2011/12/01</td>
					<td>Staff</td>
					<td><span class="label label-danger">Banned</span></td>
					<td>
						<center>
							<div class="btn-group">
								<a href="Edit.aspx" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></a>
							</div>
						</center>
					</td>   
				</tr>
				<tr>
					<td><center>3</center></td>
					<td>Andrew A. Stout</td>
					<td>2010/08/21</td>
					<td>User</td>
					<td><span class="label label-default">Inactive</span></td>
					<td>
						<center>
							<div class="btn-group">
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></a>
							</div>
						</center>
					</td>                                           
				</tr>
				<tr>
					<td><center>4</center></td>
					<td>Mary M. Bryan</td>
					<td>2009/04/11</td>
					<td>Editor</td>
					<td><span class="label label-warning">Pending</span></td>
					<td>
						<center>
							<div class="btn-group">
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></a>
							</div>
						</center>
					</td>                                          
				</tr>
				<tr>
					<td><center>5</center></td>
					<td>Mary A. Lewis</td>
					<td>2007/02/01</td>
					<td>Staff</td>
					<td><span class="label label-success">Active</span></td>
					<td>
						<center>
							<div class="btn-group">
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
								<a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></a>
							</div>
						</center>
					</td>                                           
				</tr>
			</tbody>
		</table>
		<center>
			<ul class="pagination">
				<li><a href="#">&laquo;</a></li>
				<li><a href="#">1</a></li>
				<li><a href="#">2</a></li>
				<li><a href="#">3</a></li>
				<li><a href="#">4</a></li>
				<li><a href="#">5</a></li>
				<li><a href="#">&raquo;</a></li>
			</ul>
		</center>
	</div>
</div>
</asp:Content>
