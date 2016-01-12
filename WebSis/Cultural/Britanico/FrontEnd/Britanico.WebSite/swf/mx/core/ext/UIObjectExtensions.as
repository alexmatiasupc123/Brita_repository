class mx.core.ext.UIObjectExtensions
{
    var __enabled, invalidateStyle, invalidateFlag, _getTextFormat, setTextFormat, setNewTextFormat, embedFonts, __text, text, _visible, textColor, setValue, getValue, stylecache, __getTextFormat, enabledColor, getTextFormat, getStyle, draw, textWidth, textHeight, align;
    function UIObjectExtensions()
    {
    } // End of the function
    static function addGeometry(tf, ui)
    {
        tf.addProperty("width", ui.__get__width, null);
        tf.addProperty("height", ui.__get__height, null);
        tf.addProperty("left", ui.__get__left, null);
        tf.addProperty("x", ui.__get__x, null);
        tf.addProperty("top", ui.__get__top, null);
        tf.addProperty("y", ui.__get__y, null);
        tf.addProperty("right", ui.__get__right, null);
        tf.addProperty("bottom", ui.__get__bottom, null);
        tf.addProperty("visible", ui.__get__visible, ui.__set__visible);
    } // End of the function
    static function Extensions()
    {
        if (mx.core.ext.UIObjectExtensions.bExtended == true)
        {
            return (true);
        } // end if
        bExtended = true;
        var _loc4 = mx.core.UIObject.prototype;
        var _loc8 = mx.skins.SkinElement.prototype;
        mx.core.ext.UIObjectExtensions.addGeometry(_loc8, _loc4);
        mx.events.UIEventDispatcher.initialize(_loc4);
        var _loc12 = mx.skins.ColoredSkinElement;
        mx.styles.CSSTextStyles.addTextStyles(_loc4);
        var _loc5 = MovieClip.prototype;
        _loc5.getTopLevel = _loc4.getTopLevel;
        _loc5.createLabel = _loc4.createLabel;
        _loc5.createObject = _loc4.createObject;
        _loc5.createClassObject = _loc4.createClassObject;
        _loc5.createEmptyObject = _loc4.createEmptyObject;
        _loc5.destroyObject = _loc4.destroyObject;
        _loc5.__getTextFormat = _loc4.__getTextFormat;
        _loc5._getTextFormat = _loc4._getTextFormat;
        _loc5.getStyleName = _loc4.getStyleName;
        _loc5.getStyle = _loc4.getStyle;
        var _loc6 = TextField.prototype;
        mx.core.ext.UIObjectExtensions.addGeometry(_loc6, _loc4);
        _loc6.addProperty("enabled", function ()
        {
            return (__enabled);
        }, function (x)
        {
            __enabled = x;
            this.invalidateStyle();
        });
        _loc6.move = _loc8.move;
        _loc6.setSize = _loc8.setSize;
        _loc6.invalidateStyle = function ()
        {
            invalidateFlag = true;
        };
        _loc6.draw = function ()
        {
            if (invalidateFlag)
            {
                invalidateFlag = false;
                var _loc2 = this._getTextFormat();
                this.setTextFormat(_loc2);
                this.setNewTextFormat(_loc2);
                embedFonts = _loc2.embedFonts == true;
                if (__text != undefined)
                {
                    if (text == "")
                    {
                        text = __text;
                    } // end if
                    delete this.__text;
                } // end if
                _visible = true;
            } // end if
        };
        _loc6.setColor = function (color)
        {
            textColor = color;
        };
        _loc6.getStyle = _loc5.getStyle;
        _loc6.__getTextFormat = _loc4.__getTextFormat;
        _loc6.setValue = function (v)
        {
            text = v;
        };
        _loc6.getValue = function ()
        {
            return (text);
        };
        _loc6.addProperty("value", function ()
        {
            return (this.getValue());
        }, function (v)
        {
            this.setValue(v);
        });
        _loc6._getTextFormat = function ()
        {
            var _loc2 = stylecache.tf;
            if (_loc2 != undefined)
            {
                return (_loc2);
            } // end if
            _loc2 = new TextFormat();
            this.__getTextFormat(_loc2);
            stylecache.tf = _loc2;
            if (__enabled == false)
            {
                if (enabledColor == undefined)
                {
                    var _loc4 = this.getTextFormat();
                    enabledColor = _loc4.color;
                } // end if
                var _loc3 = this.getStyle("disabledColor");
                _loc2.color = _loc3;
            }
            else if (enabledColor != undefined)
            {
                if (_loc2.color == undefined)
                {
                    _loc2.color = enabledColor;
                } // end if
            } // end else if
            return (_loc2);
        };
        _loc6.getPreferredWidth = function ()
        {
            this.draw();
            return (textWidth + 4);
        };
        _loc6.getPreferredHeight = function ()
        {
            this.draw();
            return (textHeight + 4);
        };
        TextFormat.prototype.getTextExtent2 = function (s)
        {
            var _loc3 = _root._getTextExtent;
            if (_loc3 == undefined)
            {
                _root.createTextField("_getTextExtent", -2, 0, 0, 1000, 100);
                _loc3 = _root._getTextExtent;
                _loc3._visible = false;
            } // end if
            _root._getTextExtent.text = s;
            var _loc4 = align;
            align = "left";
            _root._getTextExtent.setTextFormat(this);
            align = _loc4;
            return ({width: _loc3.textWidth, height: _loc3.textHeight});
        };
        if (_global.style == undefined)
        {
            _global.style = new mx.styles.CSSStyleDeclaration();
            _global.cascadingStyles = true;
            _global.styles = new Object();
            _global.skinRegistry = new Object();
            _global.origWidth = Stage.width;
            _global.origHeight = Stage.height;
        } // end if
        _root.addProperty("width", function ()
        {
            return (Stage.width);
        }, null);
        _root.addProperty("height", function ()
        {
            return (Stage.height);
        }, null);
        return (true);
    } // End of the function
    static var bExtended = false;
    static var UIObjectExtended = mx.core.ext.UIObjectExtensions.Extensions();
    static var UIObjectDependency = mx.core.UIObject;
    static var SkinElementDependency = mx.skins.SkinElement;
    static var CSSTextStylesDependency = mx.styles.CSSTextStyles;
    static var UIEventDispatcherDependency = mx.events.UIEventDispatcher;
} // End of Class
