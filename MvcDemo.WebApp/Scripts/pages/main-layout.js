
/** Navbar Scroll Collapse */
jQuery(function ($) {
    var $win = $(window);
    var $nav = $('#NavbarWrapper');
    var navHeight = $nav.outerHeight() + 10;
    var boundary = navHeight * 1.6;
    var nextTop = 0;

    $win.on('scroll', function (e) {
        if ($nav.has('.collapse.in, .dropdown.open').length) {
            $nav.css('top', 0);
            return;
        }

        var delta = $win.scrollTop() - nextTop;
        if ($win.scrollTop() < boundary || delta < -200) {
            $nav.css('top', 0);
        } else if (delta > 40) {
            $nav.css('top', -navHeight);
            $(document).triggerHandler('click.bs.dropdown.data-api');
        } else {
            return;
        }
        nextTop = $win.scrollTop();
    }).triggerHandler('scroll');
});





/** Sidebar Menu  */
var keepSidebarFilter = 'sidebar_item_filter';

jQuery(function ($) {
    var $body = $('body');

    /* Sidebar Menu 顯示/隱藏 */
    if ($.cookie('sidebar_menu_hide') == 'true') {
        $body.addClass('menu-toggle');
    }

    /* 取消 init */
    setTimeout(function () { $body.removeClass('init'); }, 100);



    $('#MenuToggle').click(function () {
        if ($body.is('.menu-toggle')) {
            $body.removeClass('menu-toggle');
            $.cookie('sidebar_menu_hide', '', { path: '/' });
        } else {
            $body.addClass('menu-toggle');
            $.cookie('sidebar_menu_hide', 'true', { path: '/' });
        }

        setTimeout(function () {
            $(window).trigger('resize');
            $body.trigger('change.menu-toggle');
        }, 600);
    });



    /* Sidebar Menu Item 收合/展開 */
    $('#MenuList .sidebar-dropdown > .sidebar-item').click(function () {
        $(this).parent().toggleClass('open');

        var sidebarMenuOpen = $('#MenuList .sidebar-dropdown.open').map(function () {
            return $(this).attr('project');
        }).toArray().join(',');

        $.cookie('sidebar_item_open', sidebarMenuOpen, { path: '/' });
    });



    /* Sidebar Menu Item 快速過濾 */
    var sidebarMenuIndex = null;

    $('#MenuFilter input').on('init keyup change', function () {
        var filter = $.trim(this.value).toLowerCase();
        $.cookie(keepSidebarFilter, filter, { path: '/' });

        if (!filter) {
            $('#MenuList .sidebar-dropdown').removeClass('filter').show();
            $('#MenuList .sidebar-dropdown li').show();
            return;
        }

        if (!sidebarMenuIndex) {
            sidebarMenuIndex = $('#MenuList .sidebar-dropdown li').map(function () {
                var $li = $(this);
                var key = $li.attr('allow') + ' ' + $li.text();

                return {
                    key: key.toLowerCase(),
                    $element: $li,
                    $parent: $li.closest('.sidebar-dropdown')
                };
            }).toArray();
        }

        $('#MenuList .sidebar-dropdown').addClass('filter').hide();
        $.each(sidebarMenuIndex, function (i, index) {
            if (index.key.contains(filter)) {
                index.$element.show();
                index.$parent.show();
            } else {
                index.$element.hide();
            }
        });
    });

    var filter = $.cookie(keepSidebarFilter);
    $('#MenuFilter input').val(filter).trigger('init');

});



