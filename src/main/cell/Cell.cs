using Godot;
using System;
using System.Collections.Generic;
using NumbersMergeGame;
public class Cell : ModelNode2D
{
    [Export]
    public bool CreateModel = false;
    //Components
    private Area2D _clickCollisionArea;
    private Area2D _cellCollisionArea;
    private Label _numberLabel;
    private ColorRect _backgroundColorRect;
    //Inside vars
    private bool _isMoving = false;
    private Vector2 _positionMouseDelta;
    public Color Color
    {
        get { return _backgroundColorRect.Color; }
    }
    public override void _Ready()
    {
        ConnectComponents();
        ConnectSelfEventHandlers();
        ConnectSignals();
        if (CreateModel)
        {
            this.Model = new CellModel(0, 0);
        }
    }

    private void ConnectComponents()
    {
        _clickCollisionArea = GetNode<Area2D>("ClickCollisionArea");
        _cellCollisionArea = GetNode<Area2D>("CellCollisionArea");
        _numberLabel = GetNode<Label>("NumberText");
        _backgroundColorRect = GetNode<ColorRect>("BackgroundColorRect");
    }
    private void ConnectSelfEventHandlers()
    {
        this.ModelSettedEvent += OnModelSetted;    
    }

    private void ConnectSignals() 
    {
        _clickCollisionArea.Connect("input_event", this, "OnClickAreaInputEvent");
        _cellCollisionArea.Connect("area_entered", this, "OnCellAreaEnteredEvent");
    }
    public override void _Process(float delta)
    {
        if(_isMoving == true)
        {
            CellMovingProccess(delta);
        }
    }

    public void OnClickAreaInputEvent(Node viewport, InputEvent @event, int shape_idx)
    {
        if(@event is InputEventMouseButton)
        {
            InputEventMouseButton mouseEvent = (InputEventMouseButton)@event;
            if (mouseEvent.IsPressed() && mouseEvent.ButtonIndex == (int)ButtonList.Left)
            {
                if (Model != null) ((CellModel)this.Model).GradeCellToNextValue();
                _isMoving = true;
                _positionMouseDelta = GetViewport().GetMousePosition() - this.Position;
                ZIndex = 2;
                GD.Print(ZIndex);
                GD.Print("MOVE!");
            }
            else if(mouseEvent.Pressed == false && mouseEvent.ButtonIndex == (int)ButtonList.Left) 
            {
                ZIndex = 0;
                GD.Print("STOP;");
                _isMoving = false;
            }
        }
    }
    public void OnCellAreaEnteredEvent(Area2D area) 
    {
        //Check collisions
        if (area.Name != "CellCollisionArea") return;
        ModelNode2D cellNode = area.GetParentOrNull<ModelNode2D>();
        if (cellNode == null) return;
        //Check Values
        if (_isMoving == false) return;
        CellModel otherModel = (CellModel)cellNode.Model;
        CellModel selfModel = (CellModel)Model;
        if (otherModel.Value != selfModel.Value) return;

        otherModel.GradeCellToNextValue();
        GetParent().RemoveChild(this);
    }
    private void OnModelSetted(object sender, ModelSettedEventArgs e)
    {
        ((CellModel)this.Model).ValueChangedEvent += OnCellValueChanged;
    }
    private void OnCellValueChanged(object sender, ValueChangedEventArgs e)
    {
        _numberLabel.Text = e.NewValue.ToString();
        _backgroundColorRect.Color = GameColors.GetColorByValue((GameColors.CellSteps)e.NewValue);
    }

    private void CellMovingProccess(float delta)
    {
        Vector2 mousePosition = GetViewport().GetMousePosition();
        this.Position = mousePosition - _positionMouseDelta;
    }
}
