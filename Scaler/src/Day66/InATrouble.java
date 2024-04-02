package Day66;

import java.util.*;

/*Ram has given array A of size N. He has to perform N operations on the array. In the operations
1. Select minimum (suppose A) and maximum (suppose C) of array and find the average of both the numbers (AVG = (B + C)/2);
2. Replace the minimum value B to B + Avg
3. Replace the minimum value C to B - Avg
*/

public class InATrouble {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] array = {3, 2, 7};
        int[] ans  = new InATrouble().performOperations(array);
        System.out.println("array " + ans.toString());
	}

	public int[] performOperations(int[] array) {
        int n = array.length;
        for (int i = 0; i < n; i++) {
            Arrays.sort(array);
            int min = array[0];
            int max = array[n - 1];
            int avg = (min + max) / 2;
            System.out.print(avg + " avg ");
            array[0] += avg;
            array[n - 1] -= avg;
        }
        return array;
    }
}
