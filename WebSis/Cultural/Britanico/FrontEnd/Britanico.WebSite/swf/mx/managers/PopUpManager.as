class mx.managers.PopUpManager
{
    var popUp, setSize, move, modalWindow, _parent, _name, _visible, owner;
    function PopUpManager()
    {
    } // End of the function
    static function createModalWindow(parent, o, broadcastOutsideEvents)
    {
        var _loc2 = parent.createChildAtDepth("Modal", mx.managers.DepthManager.kTopmost);
        _loc2.setDepthBelow(o);
        o.modalID = _loc2._name;
        _loc2._alpha = _global.style.modalTransparency;
        _loc2.tabEnabled = false;
        if (broadcastOutsideEvents)
        {
            _loc2.onPress = mx.managers.PopUpManager.mixins.onPress;
        }
        else
        {
            _loc2.onPress = mx.managers.PopUpManager.mixins.nullFunction;
        } // end else if
        _loc2.onRelease = mx.managers.PopUpManager.mixins.nullFunction;
        _loc2.resize = mx.managers.PopUpManager.mixins.resize;
        mx.managers.SystemManager.init();
        mx.managers.SystemManager.addEventListener("resize", _loc2);
        _loc2.resize();
        _loc2.useHandCursor = false;
        _loc2.popUp = o;
        o.modalWindow = _loc2;
        o.deletePopUp = mx.managers.PopUpManager.mixins.deletePopUp;
        o.setVisible = mx.managers.PopUpManager.mixins.setVisible;
        o.getVisible = mx.managers.PopUpManager.mixins.getVisible;
        o.addProperty("visible", o.getVisible, o.setVisible);
    } // End of the function
    static function createPopUp(parent, className, modal, initobj, broadcastOutsideEvents)
    {
        if (mx.managers.PopUpManager.mixins == undefined)
        {
            mixins = new mx.managers.PopUpManager();
        } // end if
        if (broadcastOutsideEvents == undefined)
        {
            broadcastOutsideEvents = false;
        } // end if
        while (parent._parent != undefined)
        {
            parent = parent._parent;
        } // end while
        initobj.popUp = true;
        var _loc3 = parent.createClassChildAtDepth(className, broadcastOutsideEvents || modal ? (mx.managers.DepthManager.kTopmost) : (mx.managers.DepthManager.kTop), initobj);
        if (_root.focusManager != undefined)
        {
            _loc3.createObject("FocusManager", "focusManager", -1);
            if (_loc3._visible == false)
            {
                mx.managers.SystemManager.deactivate(_loc3);
            } // end if
        } // end if
        if (modal)
        {
            mx.managers.PopUpManager.createModalWindow(parent, _loc3, broadcastOutsideEvents);
        }
        else
        {
            if (broadcastOutsideEvents)
            {
                _loc3.mouseListener = new Object();
                _loc3.mouseListener.owner = _loc3;
                _loc3.mouseListener.onMouseDown = mx.managers.PopUpManager.mixins.onMouseDown;
                Mouse.addListener(_loc3.mouseListener);
            } // end if
            _loc3.deletePopUp = mx.managers.PopUpManager.mixins.deletePopUp;
        } // end else if
        return (_loc3);
    } // End of the function
    function onPress(Void)
    {
        if (popUp.hitTest(_root._xmouse, _root._ymouse, false))
        {
            return;
        } // end if
        popUp.dispatchEvent({type: "mouseDownOutside"});
    } // End of the function
    function nullFunction(Void)
    {
    } // End of the function
    function resize(Void)
    {
        var _loc2 = mx.managers.SystemManager.__get__screen();
        this.setSize(_loc2.width, _loc2.height);
        this.move(_loc2.x, _loc2.y);
    } // End of the function
    function deletePopUp(Void)
    {
        if (modalWindow != undefined)
        {
            _parent.destroyObject(modalWindow._name);
        } // end if
        _parent.destroyObject(_name);
    } // End of the function
    function setVisible(v, noEvent)
    {
        super.setVisible(v, noEvent);
        modalWindow._visible = v;
    } // End of the function
    function getVisible(Void)
    {
        return (_visible);
    } // End of the function
    function onMouseDown(Void)
    {
        if (owner.hitTest(_root._xmouse, _root._ymouse, false))
        {
        }
        else
        {
            owner.mouseDownOutsideHandler(owner);
        } // end else if
    } // End of the function
    static var version = "2.0.0.360";
    static var mixins = undefined;
} // End of Class
