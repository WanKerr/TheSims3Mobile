// Decompiled with JetBrains decompiler
// Type: UIScrollable
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework.Input;
using midp;
using System;

public class UIScrollable : UIElement
{
    private const int SCROLLSTATE_IDLE = 0;
    private const int SCROLLSTATE_CHOOSE = 1;
    private const int SCROLLSTATE_SCROLLING = 2;
    private const int SCROLLSTATE_SWIPING = 3;
    private int m_scrollState;
    private int m_draggablePosX;
    private int m_draggablePosY;
    private int m_draggableWidth;
    private int m_draggableHeight;
    private bool m_scrollingEnabled;
    private float m_scrollOffsetY;
    private float m_scrollOffsetYMin;
    private float m_scrollOffsetYMax;
    private float m_scrollDragVel;
    private float m_scrollOffsetYDest;
    private bool m_swipingEnabled;
    private float m_swipeOffset;
    private float m_swipeOffsetMin;
    private float m_swipeOffsetMax;
    private float m_swipeNotchSize;
    protected float m_swipeDragVel;
    private float m_swipeOffsetDest;
    private int m_scrollValue;
    private int m_previousDelta;

    public UIScrollable()
    {
        this.m_scrollState = 0;
        this.m_draggablePosX = 0;
        this.m_draggablePosY = 0;
        this.m_draggableWidth = 0;
        this.m_draggableHeight = 0;
        this.m_scrollingEnabled = false;
        this.m_scrollOffsetY = 0.0f;
        this.m_scrollOffsetYMin = 0.0f;
        this.m_scrollOffsetYMax = 0.0f;
        this.m_scrollDragVel = 0.0f;
        this.m_scrollOffsetYDest = 0.0f;
        this.m_swipingEnabled = false;
        this.m_swipeOffset = 0.0f;
        this.m_swipeOffsetMin = 0.0f;
        this.m_swipeOffsetMax = 0.0f;
        this.m_swipeNotchSize = 0.0f;
        this.m_swipeDragVel = 0.0f;
        this.m_swipeOffsetDest = 0.0f;
        this.m_scrollValue = Mouse.GetState().ScrollWheelValue;
    }

    public new void Dispose()
    {
        base.Dispose();
    }

    public override void processInput(int _event, int[] args)
    {
        var state = Mouse.GetState();
        var current = state.ScrollWheelValue;
        var original = m_scrollValue;
        var delta = current - original;
        var previousDelta = m_previousDelta;
        m_previousDelta = delta;
        m_scrollValue = state.ScrollWheelValue;

        switch (this.m_scrollState)
        {
            case 0:
                if (delta == 0 && (_event != 4 || !this.m_scrollingEnabled && !this.m_swipingEnabled || !UIElement.isInBox(args[1], args[2], this.m_draggablePosX, this.m_draggablePosY, this.m_draggableWidth, this.m_draggableHeight)))
                    break;
                this.stateTransitionScrollable(1);
                break;
            case 1:
                switch (_event)
                {
                    case 5:
                        int num1 = args[1]; // x1
                        int num2 = args[2]; // y1
                        int num3 = args[5]; // x2
                        int num4 = args[6]; // y2
                        int a1 = num1 - num3;
                        int a2 = num2 - num4;
                        if (a1 == 0 && a2 == 0)
                            return;
                        if (JMath.abs(a1) > JMath.abs(a2))
                        {
                            if (!this.m_swipingEnabled)
                                return;
                            this.stateTransitionScrollable(3);
                            this.processInputSwiping(_event, args);
                            return;
                        }
                        if (!this.m_scrollingEnabled)
                            return;
                        this.stateTransitionScrollable(2);
                        this.processInputScrolling(_event, args);
                        return;
                    case 6:
                        this.stateTransitionScrollable(0);
                        return;
                    default:
                        if (delta != 0)
                            this.stateTransitionScrollable(this.m_swipingEnabled ? 3 : 2);
                        return;
                }
            case 2:
                if (delta != 0)
                {
                    Array.Resize(ref args, 10);

                    args[2] = original / 5;
                    args[6] = current / 5;
                    args[9] = delta / 5;
                    this.processInputScrolling(5, args);
                }
                else
                {
                    this.processInputScrolling(_event, args);
                }
                break;
            case 3:
                if (delta != 0)
                {
                    Array.Resize(ref args, 10);

                    args[1] = original / 5;
                    args[5] = current / 5;
                    args[9] = delta / 5;
                    this.processInputSwiping(5, args);
                }
                else
                {
                    this.processInputSwiping(_event, args);
                }
                break;
        }

    }
    private void processInputScrolling(int _event, int[] args)
    {
        switch (_event)
        {
            case 5:
                int num1 = args[2];
                int num2 = args[6] - num1;
                this.m_scrollOffsetY = JMath.max(JMath.min(this.m_scrollOffsetY + (float)num2, this.m_scrollOffsetYMax), this.m_scrollOffsetYMin);
                this.m_scrollOffsetYDest = this.m_scrollOffsetY;
                int num3 = args[9];
                this.m_scrollDragVel = (float)num2 / (float)num3;
                break;
            case 6:
                if ((double)JMath.abs(this.m_scrollDragVel) > 0.200000002980232)
                    this.m_scrollOffsetYDest = MathExt.clip(this.m_scrollOffsetY + this.m_scrollDragVel * 150f, this.m_scrollOffsetYMin, this.m_scrollOffsetYMax);
                this.stateTransitionScrollable(0);
                this.onEndScroll();
                break;
        }
    }

    private void processInputSwiping(int _event, int[] args)
    {
        switch (_event)
        {
            case 5:
                int num1 = args[1];
                int num2 = args[5] - num1;
                int swipeOffset = (int)this.m_swipeOffset;
                this.m_swipeOffset = JMath.max(JMath.min(this.m_swipeOffset + (float)num2, this.m_swipeOffsetMax), this.m_swipeOffsetMin);
                this.m_swipeOffsetDest = this.m_swipeOffset;
                int num3 = args[9];
                this.m_swipeDragVel = (float)num2 / (float)num3;
                this.checkMidSwipe((float)swipeOffset, this.m_swipeOffset);
                break;
            case 6:
                if ((double)JMath.abs(this.m_swipeDragVel) > 0.200000002980232)
                {
                    float num4 = this.m_swipeDragVel * 45f;
                    if ((double)num4 > 0.0 && (double)num4 < (double)this.m_swipeNotchSize)
                        num4 = this.m_swipeNotchSize;
                    else if ((double)num4 < 0.0 && (double)num4 > -(double)this.m_swipeNotchSize)
                        num4 = -this.m_swipeNotchSize;
                    this.m_swipeOffsetDest = this.getSwipeNotchOffset(this.m_swipeOffset + num4);
                }
                this.stateTransitionScrollable(0);
                this.onEndSwipe();
                break;
        }
    }

    private void stateTransitionScrollable(int state)
    {
        this.m_scrollState = state;
        switch (state)
        {
            case 0:
                this.getScene().deactivateUIElement((UIElement)this);
                break;
            case 2:
                this.getScene().activateUIElement((UIElement)this);
                this.onBeginScroll();
                break;
            case 3:
                this.getScene().activateUIElement((UIElement)this);
                this.onBeginSwipe();
                break;
        }
    }

    public void setDragArea(int x, int y, int width, int height)
    {
        this.m_draggablePosX = x;
        this.m_draggablePosY = y;
        this.m_draggableWidth = width;
        this.m_draggableHeight = height;
    }

    public int getDragAreaX()
    {
        return this.m_draggablePosX;
    }

    public int getDragAreaY()
    {
        return this.m_draggablePosY;
    }

    public int getDragAreaWidth()
    {
        return this.m_draggableWidth;
    }

    public int getDragAreaHeight()
    {
        return this.m_draggableHeight;
    }

    public bool isInDragArea(int x, int y)
    {
        return UIElement.isInBox(x, y, this.m_draggablePosX, this.m_draggablePosY, this.m_draggableWidth, this.m_draggableHeight);
    }

    public void resetScrolling()
    {
        this.resetScrolling(true);
    }

    public void resetScrolling(bool enabled)
    {
        this.m_scrollingEnabled = enabled;
        this.stateTransitionScrollable(0);
    }

    public void resetSwiping()
    {
        this.resetSwiping(true);
    }

    public void resetSwiping(bool enabled)
    {
        this.m_swipingEnabled = enabled;
        this.stateTransitionScrollable(0);
    }

    public void setScrollRange(float min, float max)
    {
        this.m_scrollOffsetYMin = min;
        this.m_scrollOffsetYMax = max;
    }

    public void setScrollOffset(float offset)
    {
        this.m_scrollOffsetY = offset;
        this.m_scrollOffsetYDest = offset;
    }

    public float getScrollOffset()
    {
        return this.m_scrollOffsetY;
    }

    public float getScrollRangeMin()
    {
        return this.m_scrollOffsetYMin;
    }

    public float getScrollRangeMax()
    {
        return this.m_scrollOffsetYMax;
    }

    public void setSwipeRange(float min, float max, float notch)
    {
        this.m_swipeOffsetMin = min;
        this.m_swipeOffsetMax = max;
        this.m_swipeNotchSize = notch;
    }

    public void setSwipeOffset(float offset)
    {
        this.m_swipeOffset = offset;
        this.m_swipeOffsetDest = offset;
    }

    public float getSwipeOffset()
    {
        return this.m_swipeOffset;
    }

    public void setSwipeOffsetDest(float offset)
    {
        this.m_swipeOffsetDest = offset;
    }

    public float getSwipeRangeMin()
    {
        return this.m_swipeOffsetMin;
    }

    public float getSwipeRangeMax()
    {
        return this.m_swipeOffsetMax;
    }

    protected int getSwipeNotch(float offset)
    {
        return MathExt.clip((double)offset > 0.0 ? (int)(((double)offset + (double)this.m_swipeNotchSize * 0.5) / (double)this.m_swipeNotchSize) : (int)(((double)offset - (double)this.m_swipeNotchSize * 0.5) / (double)this.m_swipeNotchSize), (int)((double)this.m_swipeOffsetMin / (double)this.m_swipeNotchSize), (int)((double)this.m_swipeOffsetMax / (double)this.m_swipeNotchSize));
    }

    protected float getSwipeNotchOffset(float offset)
    {
        return (float)this.getSwipeNotch(offset) * this.m_swipeNotchSize;
    }

    public bool itemsLeft()
    {
        return (double)this.getSwipeOffset() < (double)this.getSwipeRangeMax();
    }

    public bool itemsRight()
    {
        return (double)this.getSwipeOffset() > (double)this.getSwipeRangeMin();
    }

    public void submitScrollbar(
      ref AnimationManager2D am2d,
      int scrollValue,
      int scrollVisible,
      int scrollTotal,
      float barX,
      float barY,
      float barHeight)
    {
        float h = barHeight * (float)JMath.min(scrollVisible, scrollTotal) / (float)scrollTotal;
        float y = (float)((double)barY + ((double)barHeight - (double)h) * (double)scrollValue / (double)(scrollTotal - scrollVisible) + (double)h * 0.5 - (double)barHeight * 0.5);
        am2d.submitAnimVBar(128, 129, 130, barX, barY, barHeight);
        am2d.submitAnimVBar(131, 132, 133, barX, y, h);
    }

    public override void update(int timeStep)
    {
        if (this.m_scrollState != 0)
            return;
        if ((double)this.m_swipeOffset != (double)this.m_swipeOffsetDest)
        {
            float swipeOffset = this.m_swipeOffset;
            this.m_swipeOffset = (float)MathExt.interpFilter(this.m_swipeOffset, this.m_swipeOffsetDest, timeStep, 0.005f);
            this.checkMidSwipe(swipeOffset, this.m_swipeOffset);
        }
        else if ((double)this.m_scrollOffsetY != (double)this.m_scrollOffsetYDest)
        {
            this.m_scrollOffsetY = (float)MathExt.interpFilter(this.m_scrollOffsetY, this.m_scrollOffsetYDest, timeStep, 0.005f);
        }
        else
        {
            if ((double)this.m_swipeNotchSize == 0.0)
                return;
            float swipeNotchOffset = this.getSwipeNotchOffset(this.m_swipeOffset);
            float num = (float)(400.0 * ((double)timeStep / 1000.0));
            if ((double)swipeNotchOffset > (double)this.m_swipeOffset)
                this.m_swipeOffset = JMath.min(swipeNotchOffset, this.m_swipeOffset + num);
            else if ((double)swipeNotchOffset < (double)this.m_swipeOffset)
                this.m_swipeOffset = JMath.max(swipeNotchOffset, this.m_swipeOffset - num);
            this.m_swipeOffsetDest = this.m_swipeOffset;
        }
    }

    private void checkMidSwipe(float oldOffset, float newOffset)
    {
        if ((double)this.getSwipeNotchOffset(oldOffset) == (double)this.getSwipeNotchOffset(newOffset))
            return;
        this.onMidSwipe();
    }

    public virtual void onBeginScroll()
    {
    }

    public virtual void onEndScroll()
    {
    }

    public virtual void onBeginSwipe()
    {
    }

    public virtual void onEndSwipe()
    {
    }

    public virtual void onMidSwipe()
    {
    }
}
