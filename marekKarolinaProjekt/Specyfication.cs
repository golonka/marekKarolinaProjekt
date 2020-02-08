using System;

public class Specyfication
{

    private readonly String ram;
    private readonly String graphic;
    private readonly String processor;
    private readonly String screen;

    public Specyfication(String ram, String graphic, String processor, String screen)
    {
        this.ram = ram;
        this.graphic = graphic;
        this.processor = processor;
        this.screen = screen;
    }

    public String Ram { get => ram; }

    public String Graphic { get => graphic; }

    public String Processor { get => processor; }

    public String Screen { get => screen; }

}
