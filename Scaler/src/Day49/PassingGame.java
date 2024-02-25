package Day49;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Stack;

public class PassingGame {

	public static void main(String[] args) {
		int A = 10;
		int B = 23;
		ArrayList<Integer> C = new ArrayList<Integer>(Arrays.asList(86, 63, 60, 0, 47, 0, 99, 9, 0, 0));
		int ans = solve(A, B, C);
		System.out.print(ans);
	}
	public static int solve(int A, int B, ArrayList<Integer> C) {
        Stack <Integer> stk=new Stack<>();
        stk.push(B);
        for(int x:C){
            if(x==0){
                stk.pop();
            }else{
                stk.push(x);
            }
        }
        return stk.peek();
    }
}
