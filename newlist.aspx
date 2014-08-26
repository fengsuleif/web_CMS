<%@ page language="C#" autoeventwireup="true" CodeFile="newlist.cs" Inherits="newlist" EnableViewState="false" %>
<!DOCTYPE html>
<html lang="zh-hans" class="js">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
<meta name="keywords" content="人权捍卫者">
<meta name="description" content="人权捍卫者">
<meta name="copyright" content="人权捍卫者">
<title>人权捍卫者</title>
<link rel="shortcut icon" href="favicon.ico" type="image/vnd.microsoft.icon">

<link type="text/css" rel="stylesheet" href="./source_files/css_annzq1por5zLXwLbd5-vpftJX919s8C1XDTGtqa5vGk.css" media="all">
<link type="text/css" rel="stylesheet" href="./source_files/css_2Jdp4oe0PE0jbUbNo79ZliVwjcmoHadtNxamsngcBXI.css" media="print">
<link type="text/css" rel="stylesheet" href="./source_files/colorbox.css" media="all">
<!--[if IE]>
<link type="text/css" rel="stylesheet" href="./source_files/1nk.css" media="all" />
<![endif]-->

<!--[if lte IE 6]>
<link type="text/css" rel="stylesheet" href="./source_files/2nk.css" media="all" />
<![endif]-->


<script src="./source_files//jquery.min.js"></script>


<script type="text/javascript" src="./source_files/jquery.colorbox.js"></script>
  <!--[if lt IE 9]>
    <script src="./source_files/html5.js"></script>
  <![endif]-->
  
 <script>
     $(document).ready(function () {
         //Examples of how to assign the Colorbox event to elements


         $(".cboxElement").colorbox({ iframe: true, width: "68%", height: "78%" });

     });
		</script>
</head>


<body class="html not-front not-logged-in no-sidebars page-node page-node- page-node-1143 node-type-course section-course transition" screen_capture_injected="true"><div id="cboxOverlay" style="display: none;"></div><div id="colorbox" class="" style="padding-bottom: 25px; padding-right: 30px; display: none;"><div id="cboxWrapper" style=""><div style=""><div id="cboxTopLeft" style="float: left;"></div><div id="cboxTopCenter" style="float: left;"></div><div id="cboxTopRight" style="float: left;"></div></div><div style="clear: left;"><div id="cboxMiddleLeft" style="float: left;"></div><div id="cboxContent" style="float: left;"><div id="cboxLoadedContent" class="" style="width: 0px; height: 0px; overflow: hidden;"></div><div id="cboxLoadingOverlay" class="" style=""></div><div id="cboxLoadingGraphic" class="" style=""></div><div id="cboxTitle" class="" style=""></div><div id="cboxCurrent" class="" style=""></div><div id="cboxNext" class="" style=""></div><div id="cboxPrevious" class="" style=""></div><div id="cboxSlideshow" class="" style=""></div><div id="cboxClose" class="" style=""></div></div><div id="cboxMiddleRight" style="float: left;"></div></div><div style="clear: left;"><div id="cboxBottomLeft" style="float: left;"></div><div id="cboxBottomCenter" style="float: left;"></div><div id="cboxBottomRight" style="float: left;"></div></div></div><div style="position: absolute; width: 9999px; visibility: hidden; display: none;"></div></div>
  <header id="header">
  <div class="header-inner">
    <div class="container">
      <nav class="navbar navbar-inverse"> 
	  <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </a>
                  <a class="brand span3" href="index.aspx" title="首页" rel="home" id="A1">
				<img src="./list_files/logo.png" alt="首页"></a>
                <h2 class="element-invisible">主菜单</h2>
				<ul id="main-menu" class="nav">
				<li class="menu-578 active first">
				<a href="index.aspx" class="active">首页</a></li>
                 <asp:Repeater ID="menudh" runat="server">
                    <ItemTemplate> 
				<li class="menu-1902 last">
				<a href="newlist.aspx?lid=<%#Eval("id")%>"><%#Eval("Class")%></a></li>
                </ItemTemplate>
            </asp:Repeater>			
				
				</ul> 
       <div class="nav-collapse">
           <ul id="secondary-menu" class="nav pull-right"> 
            <li><a class="signup btn btn-primary btn-mini" href="http://hrdcare.org/rss.ashx" >订阅</a></li>
          </ul>
      </div>
      </nav>
    </div>
  </div>
</header>


<div id="showcase-course">     <section class=" first clearfix">
          
 <div style="background:url(./source_files/drupal-web-services-showcase.jpg) no-repeat 50% 0;width:100%;height:327px">
<div class="alpha-line">
<div class="container">
<div class="row">
<div class="span4">
<div class="course-promo clearfix">
    
  
  
</div> </div>
</div>
</div>
</div>
</div>
 </section></div>
<div id="showcase-course-title">
  <div class="container">    <section class=" first clearfix">
          <div class="view-dom-id-361ed902bcf7dd2d8b8ee603de065fe2">
          
          <div class="views-row views-row-1 views-row-odd views-row-first views-row-last course-info">
      
          <h1>关注中国人权捍卫者</h1>    
          <p class="course-alias">人权捍卫者手册</p>    
             </div>
  
  
  
  
  
  </div></section></div>
</div>
<div id="feature">
  <div class="container">     <section class="visible-desktop first clearfix">
          <div class="signup-tip yh"><% string [] str=getDsum(); %>
	<span>当前栏目</span><a class="btn btn-primary btn-large span2" href="newlist.aspx?lid=<%=str[3]%>" ><%=str[2]%></a> </div>
</section> </div>
</div>
<div id="mainbody">
  <div class="container">
    <div class="row">
      <div class="span8">
        <div class="maincontent">    <section class=" first clearfix">
          <div class="course-video-list view-dom-id-7c855cbd3baf174241b67b822a410fe9">
        
  
  
      <div class="view-content">
      <table class="views-table cols-2 table">
    <thead>
    <tr>
              <th>
          目录        </th>
              <th>
          时间        </th>
          </tr>
  </thead>
  <tbody>
  <asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate> 
          <tr class="odd views-row-first">
                  <td>
            <a href="ajaxview.aspx?id=<%#Eval("id")%>" class="cboxElement"><%#Eval("Titel")%> </a>          </td>
                  <td>
            <%#Eval("S_img").ToString()%>          </td>
              </tr>
         
         <p>  </p></li>
</ItemTemplate>
</asp:Repeater>
         
      </tbody>
</table>
    </div>
  
  
</div> </section>                   
    <section class=" first clearfix">
          <div id="node-1143" class="node node-course view-mode-full clearfix" about="/course/1143" typeof="sioc:Item foaf:Document">        
  <div class="node-content">
             
  </div>
   </div>
<!-- /.node --> 
</section></div>
         </div>
            <aside id="sidebar" class="span4">   
			<div class="region region-sidebar"><div class="section">
			
    <section class=" first clearfix">
          <div class="course-details view-dom-id-373480617f314a081f5c688fdc2b2721">
          
          <div class="views-row views-row-1 views-row-odd views-row-first views-row-last">
      
           
       
          <div class="box"><a href="http://hrdcare.org/upload/humanright.pdf" class="btn btn-danger disabled" rel="nofollow">下载资料</a></div>    
          <div class="field-content box"><p><a href="http://hrdcare.org/upload/humanright.pdf"> <img class="img-polaroid" style="width:175px" src="./source_files/human.jpg"></a></p>
		  <p class="hidden-phone"><a href="http://hrdcare.org/upload/humanright.pdf">人权捍卫者手册电子版下载 </a></p>
</div>    
          
    </div>
  
  </div></section>  </div></div><!-- /.section, /.region -->
 </aside>
          </div>
  </div>
</div>



<footer id="footer">
  <div class="container"> <section class=" first clearfix">   

<a href="" rel="nofollow">隐私条款</a><span>|</span>
<a href="" rel="nofollow">服务条款</a><span>|</span>
</p>
</section></div>
 
</footer> 

  
</body></html>


