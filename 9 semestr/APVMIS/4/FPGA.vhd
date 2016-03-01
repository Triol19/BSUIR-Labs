----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    14:07:31 10/10/2014 
-- Design Name: 
-- Module Name:    FPGA_Device - Behavioral 
-- Project Name: 
-- Target Devices: 
-- Tool versions: 
-- Description: 
--
-- Dependencies: 
--
-- Revision: 
-- Revision 0.01 - File Created
-- Additional Comments: 
--
----------------------------------------------------------------------------------
library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
library UNISIM;
use UNISIM.VComponents.all;

entity FPGA_Device is
    Port ( 
			  sysclk_p : in  STD_LOGIC;
			  sysclk_n : in  STD_LOGIC;
			  leds: out STD_LOGIC_VECTOR (0 to 4);
			  buttons : in  STD_LOGIC_VECTOR (0 to 8)
			  );
end FPGA_Device;

architecture Behavioral of FPGA_Device is

	component Counter is
		Port ( G : in  STD_LOGIC;
           R : in  STD_LOGIC;
           CCLR : in  STD_LOGIC;
           UP : in  STD_LOGIC;
           LOAD : in  STD_LOGIC;
           ENP : in  STD_LOGIC;
           ENT : in  STD_LOGIC;
           CLOCK : in  STD_LOGIC;
			  CLOCK_N : in  STD_LOGIC;
           A, B, C, D : in  STD_LOGIC;
           Qa, Qb, Qc, Qd : out  STD_LOGIC;
           RCO : out  STD_LOGIC);		  
	end component Counter;
	
begin
	Counter0: Counter port map ( 
			  G => '0',
           R => buttons(5),
           CCLR => not buttons(6),
           UP => not buttons(4),
           LOAD => not buttons(7),
           ENP => buttons(8),
           ENT => '0',
           A => buttons(0), 
			  B => buttons(1), 
			  C => buttons(2), 
			  D => buttons(3),
			  CLOCK => sysclk_p,
			  CLOCK_N => sysclk_n,
           Qa => leds(0),
			  Qb => leds(1), 
			  Qc => leds(2), 
			  Qd => leds(3),
           RCO  => leds(4));

end Behavioral;