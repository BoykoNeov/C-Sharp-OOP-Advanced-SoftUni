using System;
using System.Text;

public class Clinic
{
    private Pet[] rooms;
    private int occupiedRoomsCount;
    private string name;

    public int OccupiedRoomsCount
    {
        get { return occupiedRoomsCount; }
        set { occupiedRoomsCount = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Clinic(string name, int roomsCount)
    {
        if (roomsCount % 2 == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        this.rooms = new Pet[roomsCount];
        this.Name = name;
    }

    public bool AddPet(Pet pet)
    {
        if (!this.HasEmptyRooms())
        {
            return false;
        }
        else
        {
            int middleRoom = (int)(Math.Floor(this.rooms.Length / 2d));

            if (this.rooms[middleRoom] == null)
            {
                this.rooms[middleRoom] = pet;
                occupiedRoomsCount++;
                return true;
            }

            for (int i = 1; i <= this.rooms.Length / 2; i++)
            {
                if (this.rooms[middleRoom - i] == null)
                {
                    this.rooms[middleRoom - i] = pet;
                    break;
                }
                else if (this.rooms[middleRoom + i] == null)
                {
                    this.rooms[middleRoom + i] = pet;
                    break;
                }
            }

            this.OccupiedRoomsCount++;
            return true;
        }
    }

    public bool ReleaseAnimal()
    {
        if (this.occupiedRoomsCount == 0)
        {
            return false;
        }
        else
        {
            int middleRoom = (int)(Math.Floor(this.rooms.Length / 2d));

            for (int i = middleRoom; i < this.rooms.Length; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    this.occupiedRoomsCount--;
                    return true;
                }
            }

            for (int i = 0; i < middleRoom; i++)
            {
                if (this.rooms[i] != null)
                {
                    this.rooms[i] = null;
                    this.occupiedRoomsCount--;
                    break;
                }
            }

            return true;
        }
    }

    public bool HasEmptyRooms()
    {
        if (this.OccupiedRoomsCount < this.rooms.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string Print(int number)
    {
        if (this.rooms[number] == null)
        {
            return "Room empty";
        }
        else
        {
            return this.rooms[number].ToString();
        }
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.rooms.Length; i++)
        {
            sb.AppendLine(this.Print(i));
        }

        return sb.ToString();
    }
}