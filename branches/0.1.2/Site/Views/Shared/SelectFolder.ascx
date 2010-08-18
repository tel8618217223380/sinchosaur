<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script src="/Content/js/ui.core.js" type="text/javascript"></script>
<script src="/Content/js/jquery.cookie.js" type="text/javascript"></script>
<link href="/Content/js/dynatree/skin/ui.dynatree.css" rel="stylesheet" type="text/css" />
<script src="/Content/js/dynatree/jquery.dynatree.min.js" type="text/javascript"></script>

<script type='text/javascript'>
        $(function () {
            $("#tree").dynatree({
                title: "<%=LocaleRes.Localize.Main%>",
                rootVisible: true,
                minExpandLevel: 1, // 1: root node is not collapsible
                persist: true,
                checkbox: false,
                selectMode: 3,
                onPostInit: function (isReloading, isError) {
                    this.reactivate();
                },
                autoCollapse: true,
                fx: { height: "toggle", duration: 200 },
                initAjax: { 
                    url: "<%=Url.RouteUrl("GetTreeNode")%>",
                    dataType: "json", 
                    data: {
                        key: "1",
                        sleep: 1,
                        mode: "baseFolders"
                    },
                    addExpandedKeyList: true 
                },
                onLazyRead: function (dtnode) {
                    dtnode.appendAjax({     
                      url: "<%=Url.RouteUrl("GetTreeNode")%>",
                      dataType: "json", 
                      data: {
                          key: dtnode.data.key,
                          sleep: 1,
                          mode: "branch"
                      }
                  });
                },
                onActivate: function (dtnode) {
                    $("#outdirectoryid").val(dtnode.data.key);
                }
            });
        });

    </script>
    <div id="tree" style="padding-bottom:12px">Loading...</div>

