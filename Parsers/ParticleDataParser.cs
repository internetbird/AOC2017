using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2017.Parsers
{
    public static class ParticleDataParser
    {

        public static List<ParticleData> ParseRows(string[] rows)
        {
            var dataList = new List<ParticleData>();

            for (int i = 0; i < rows.Length; i++)
            {
                var data = new ParticleData();

                data.Index = i;

                var regex = new Regex(@"<(?<Text>.*?)>");
                var matches = regex.Matches(rows[i]);

                //Set the position
                string[] positionParts = matches[0].Groups["Text"].Value.Split(',');

                int positionX = int.Parse(positionParts[0]);
                int positionY = int.Parse(positionParts[1]);
                int positionZ = int.Parse(positionParts[2]);

                data.Position = new Vector3(positionX, positionY, positionZ);

                //Set the velocity
                string[] velocityParts = matches[1].Groups["Text"].Value.Split(',');

                int velocityX = int.Parse(velocityParts[0]);
                int velocityY = int.Parse(velocityParts[1]);
                int velocityZ = int.Parse(velocityParts[2]);

                data.Velocity = new Vector3(velocityX, velocityY, velocityZ);

                //Set the acceleration
                string[] accelerationParts = matches[2].Groups["Text"].Value.Split(',');
                int accelerationX = int.Parse(accelerationParts[0]);
                int accelerationY = int.Parse(accelerationParts[1]);
                int accelerationZ = int.Parse(accelerationParts[2]);

                data.Acceleration = new Vector3(accelerationX, accelerationY, accelerationZ);

                dataList.Add(data);

            }

            return dataList;

        }
    }
}
